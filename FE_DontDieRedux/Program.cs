using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;
using System.IO;
using System.Net;
using System.Web;
using System.Timers;
using System.Diagnostics;

namespace FE_DontDieRedux
{
    // Class: Trivia
    // Author: Ajay Ramnarine (originally David Schuh from Session 11-1)
    // Purpose: Hold the response code and the results from the trivia received from the online API
    // Restrictions: None
    class Trivia
    {
        public int response_code;
        public List<TriviaResult> results;
    }

    // Class: TriviaResult
    // Author: Ajay Ramnarine (originally David Schuh from Session 11-1)
    // Purpose: Hold the different outputs from the trivia received from the online API
    // Restrictions: None
    class TriviaResult
    {
        public string category;
        public string type;
        public string difficulty;
        public string question;
        public string correct_answer;
        public List<string> incorrect_answers;
    }

    // Class: Program
    // Author: Ajay Ramnarine
    // Purpose: Create an adjacency matrix and list for FEQ2
    //          Create a new game based on the Don't Die game from PE22 with new features
    // Restrictions: None
    class Program
    {
        // enum to be used for the transitions of the states of the rooms and the player
        // liquid_gas and liquid_ice are used to refer to state transitions from liquid to gas and liquid to ice respectively
        enum NodeState
        {
            ice,
            liquid_gas,
            gas,
            liquid_ice
        }

        // Adjacency Matrix
        // The letters written in the rows are the nodes at which the player is located
        // The letters written in the columns are the nodes at which the player may or may not travel
        // The positive numbers (including 0) in the matrix represent the cost it takes to move between the nodes
        // Positive numbers (including 0) also represent that it is possible to move from the currently located room (or node) to another room
        // Any negative number in the matrix (which will always be -1) represents that a move between those rooms is not possible
        // The second matrix written is in parallel with the first matrix
        // It will represent the directions that can be traversed from node to node
        // N = north, S =south, E = east, and W = west
        // null values are written to represent that movement between the two nodes is impossible
        static int[,] mwGraph = new int[,]
        {
                        /*A*/   /*B*/   /*C*/   /*D*/   /*E*/   /*F*/   /*G*/   /*H*/
            /*A*/   {    -1,      1,      5,     -1,     -1,     -1,     -1,     -1 },
            /*B*/   {    -1,     -1,     -1,      1,     -1,      7,     -1,     -1 },
            /*C*/   {    -1,     -1,     -1,      0,      2,     -1,     -1,     -1 },
            /*D*/   {    -1,      1,      0,     -1,     -1,     -1,     -1,     -1 },
            /*E*/   {    -1,     -1,      2,     -1,     -1,     -1,      2,     -1 },
            /*F*/   {    -1,     -1,     -1,     -1,     -1,     -1,     -1,      4 },
            /*G*/   {    -1,     -1,     -1,     -1,     -1,      1,     -1,     -1 },
            /*H*/   {    -1,     -1,     -1,     -1,     -1,     -1,     -1,     -1 }
        };

        // Adjacency List
        // // Written as 2 parallel lists
        // The first list will represent the rooms (or nodes) as well as what rooms can be traveled to from said rooms
        // The rooms will be represented through numbers (A=0, B=1, C=2, D=3, E=4, F=5, G=6, and H=7)
        // The second list will represent the cost it takes to travel between the rooms
        // As the lists are parallel, the costs in the second list will correspond to the rooms that can be traveled to in the first list
        static int[][] lGraph = new int[][]
        {
            /*A*/ new int[] {1, 2},
            /*B*/ new int[] {3, 5},
            /*C*/ new int[] {3, 4},
            /*D*/ new int[] {1, 2},
            /*E*/ new int[] {2, 6},
            /*F*/ new int[] {7},
            /*G*/ new int[] {4, 5},
            /*H*/ null
        };

        static int[][] wGraph = new int[][]
        {
            /*A*/ new int[] {1, 5},
            /*B*/ new int[] {1, 7},
            /*C*/ new int[] {0, 2},
            /*D*/ new int[] {1, 0},
            /*E*/ new int[] {2, 2},
            /*F*/ new int[] {4},
            /*G*/ new int[] {2, 1},
            /*H*/ null
        };

        // adjacency list (neighbor, cost)
        static (int, int)[][] listGraph = new (int, int)[][]
        { 
            /*A*/ new(int, int)[] {(1,1), (2,5)},
            /*B*/ new(int, int)[] {(3,1), (5,7)},
            /*C*/ new(int, int)[] {(3,0), (4,2)},
            /*D*/ new(int, int)[] {(1,1), (2,0)},
            /*E*/ new(int, int)[] {(2,2), (6,2)},
            /*F*/ new(int, int)[] {(7,4)},
            /*G*/ new(int, int)[] {(4,2), (5,1)},
            /*H*/ null
        };

        // List of the starting states of matter of the rooms
        static int[] stateList = new int[]
        {
            (int)NodeState.ice,
            (int)NodeState.liquid_gas,
            (int)NodeState.gas,
            (int)NodeState.ice,
            (int)NodeState.liquid_gas,
            (int)NodeState.gas,
            (int)NodeState.ice,
            (int)NodeState.liquid_gas
        };

        // timer to change the states of the room
        static Timer sTimer;

        // timer for the trivia questions
        static Timer qTimer;

        // bool to check if the time to answer the trivia question has elapsed
        static bool isTimeUp = false;

        // object to safely lock parts of the game
        static Object lockObject = new object();

        // used to keep track of how many seconds have passed from the player moving from room to room
        static int timeCounter = 0;

        // Method: Main
        // Purpose: Create the game for FEQ3 based on the Don't Die game from PE22
        // Restrictions: None
        static void Main(string[] args)
        {
            // player HP and HP wager
            int playerHealth = 5;
            int playerState = (int)NodeState.ice;
            string sPlayerHPWager = null;
            int nPlayerHPWager = 0;
            bool isAlive = true;

            // player choice for trivia or look for exit
            string playerGameChoice = null;
            bool isGameChoiceValid = false;

            // string to check for player input if they would like to wager HP against a trivia question
            string playerWagerChoice = null;

            // bool to chcck if has given a valid response for the wager
            bool isWagerValid = false;
            bool isWagerNumValid = false;

            // string to check player input for answer to trivia question
            string playerTriviaAnswer = null;

            // number to keep track of player's current location
            int currentRoom = 0;
            string playerExitChoice = null;
            bool validExit = false;

            // number to keep track of how many moves it took the player to reach the end of the game and how many seconds have passed
            int moveCounter = 0;

            // setting up the timers and their elapsed events
            sTimer = new Timer(1000);
            sTimer.Elapsed += ChangeNodeStates;

            qTimer = new Timer(15000);
            qTimer.Elapsed += OutOfTime;

            // describe that there are rooms A-H, the inital states of the rooms, and how the states of the rooms change every second
            Console.WriteLine("RULES OF THE GAME: ");
            Console.WriteLine("There are 8 rooms within this maze, each starting in a specified state of matter.");
            Console.WriteLine("The rooms and there starting states are: ");

            for (int i = 0; i < stateList.Length; i++)
            {
                // prints liquid if the int in the state list is taken from the enum of liquid_gas or liquid_ice
                // otherwise will print ice or gas
                if (stateList[i] == 1 || stateList[i] == 3)
                {
                    Console.WriteLine("Room " + NumToRoom(i) + " = " + "liquid");
                }
                else
                {
                    Console.WriteLine("Room " + NumToRoom(i) + " = " + (NodeState)stateList[i]);
                }
            }

            Console.WriteLine("The rooms will change states every second from ice -> liquid -> gas -> liquid -> ice then repeating the cycle.");
            Console.WriteLine("To move to another room, your state of matter must equal the state of matter of the room you want to travel to.");
            Console.WriteLine("You, the player, start the game with 5 HP and a state of matter of ice.");
            Console.WriteLine("When occupying a room, you can choose to move to another room, change your state of matter for 1 HP, or wager your HP against a trivia question for more HP.");
            Console.WriteLine("The game ends when you reach the final room (H), or if your HP drops to zero.");
            Console.WriteLine(" ");

            // ask the player to start the game
            Console.WriteLine("Press enter to start the game: ");
            Console.ReadLine();

            // start the timer to change the states of the rooms
            sTimer.Start();

            // start a stopwatch to keep track of how much time has passed since the player has started the game
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            // while the player is alive, loop through the game elements
            while (isAlive)
            {
                // Check to see which room the player is currently in, and print a description of the room and available doors to exit from
                RoomDescription(ref currentRoom);

                if (currentRoom == 7)
                {
                    Console.WriteLine("Congratulations! You have escaped the maze with " + playerHealth + " HP remaining.");

                    // stop the stopwatch and print the amount of time that has passed since it was started
                    stopwatch.Stop();
                    Console.WriteLine("Time to complete the game: {0}s", (stopwatch.ElapsedMilliseconds / 1000));

                    // print how many moves it took the player to reach the end
                    Console.WriteLine("Amount of moves: {0}", moveCounter);

                    Console.WriteLine("Thank you for playing!");
                    break;
                }
                else
                {
                    // Print the current HP and state of the player
                    Console.WriteLine("Current Health: " + playerHealth);
                    Console.WriteLine(" ");

                    if (playerState == 1 || playerState == 3)
                    {
                        Console.WriteLine("CurrentState: liquid");
                    }
                    else
                    {
                        Console.WriteLine("Current State: " + (NodeState)playerState);
                    }

                    Console.WriteLine(" ");


                    // print the current states of the rooms
                    for (int i = 0; i < stateList.Length; i++)
                    {
                        // prints liquid if the int in the state list is taken from the enum of liquid_gas or liquid_ice
                        // otherwise will print ice or gas
                        if (stateList[i] == 1 || stateList[i] == 3)
                        {
                            Console.WriteLine("Room " + NumToRoom(i) + " = " + "liquid");
                        }
                        else
                        {
                            Console.WriteLine("Room " + NumToRoom(i) + " = " + (NodeState)stateList[i]);
                        }
                    }
                    Console.WriteLine(" ");

                    // print the current time
                    Console.WriteLine("Time elapsed: " + timeCounter + " seconds");
                    Console.WriteLine(" ");

                    // prompt the user for trivia, ask if they would like to change state, or ask if they would like to look for an exit
                    Console.WriteLine("A skull sits in the center of the room.");
                    Console.WriteLine("A red plus sign surrounded by a large \"Q\" is inscribed on the forehead.");

                    // checks the validity of the input of the player's choice
                    do
                    {
                        Console.WriteLine("Do you approach the skull(S), do you change your state (C), or do you look for an exit(E)?");
                        playerGameChoice = Console.ReadLine();

                        if (playerGameChoice.ToLower().Equals("s") || playerGameChoice.ToLower().Equals("e") || playerGameChoice.ToLower().Equals("c"))
                        {
                            isGameChoiceValid = true;
                        }
                        else
                        {
                            Console.WriteLine("Sorry, that was not an option.");
                            isGameChoiceValid = false;
                        }

                        Console.WriteLine(" ");

                    } while (!isGameChoiceValid);
                }

                if (playerGameChoice.ToLower().Equals("s"))
                {
                    do
                    {
                        // ask the user if they would like to wager HP against a trivia question
                        Console.WriteLine("The skull seems to speak up as you approach it.");
                        Console.WriteLine("\"Would you like to wager your health against a question?\" (Y/N)");
                        playerWagerChoice = Console.ReadLine();
                        Console.WriteLine(" ");

                        // check to see if the user input yes(Y) or no(N)
                        if (playerWagerChoice.ToLower().Equals("y"))
                        {
                            do
                            {
                                Console.WriteLine("\"How much HP would you like to wager?\"");
                                sPlayerHPWager = Console.ReadLine();

                                try
                                {
                                    nPlayerHPWager = Int32.Parse(sPlayerHPWager);

                                    // check to see if the wager is greater than the player's current health
                                    if (nPlayerHPWager > playerHealth)
                                    {
                                        Console.WriteLine("\"You cannot wager more life than you have!\"");
                                        isWagerNumValid = false;
                                    }
                                    else
                                    {
                                        isWagerNumValid = true;
                                    }
                                }
                                catch
                                {
                                    Console.WriteLine("\"Life is numeric, therefore I require a number, and only a number.\"");
                                    isWagerNumValid = false;
                                }

                            } while (!isWagerNumValid);

                            Console.WriteLine("\"Excellent! Let us do some trivia, shall we?\"");
                            Console.WriteLine(" ");
                            isWagerValid = true;
                        }
                        else if (playerWagerChoice.ToLower().Equals("n"))
                        {
                            Console.WriteLine("\"As you wish.\"");
                            Console.WriteLine(" ");
                            isWagerValid = true;
                        }
                        else
                        {
                            Console.WriteLine("\"I do not understand what you are saying.\"");
                            isWagerValid = false;
                        }

                    } while (!isWagerValid);

                    // set isWagerValid to false for the next time the player encounters the wager
                    isWagerValid = false;

                    // If the user chooses to wager HP for trivia
                    // Tell them they have 15 seconds to answer the question
                    // If the answer is correct, they will gain the HP they wager
                    // If the answer is incorrect, they will lose HP
                    if (playerWagerChoice.ToLower().Equals("y"))
                    {
                        Console.WriteLine("\"You will have 15 seconds to answer my question.\"");
                        Console.WriteLine("\"Should time run out, or you answer incorrectly, I will take the HP you wagered from you.\"");
                        Console.WriteLine("\"Should you answer correctly, you shall gain the HP you wagered.\"");
                        Console.WriteLine("\"Make sure to write your answer exactly as is written amongst the other answers.\"");
                        Console.WriteLine("\"Let us begin!\"");
                        Console.WriteLine(" ");

                        Trivia triviaToAsk = AskTrivia();

                        // initialize timer boolean
                        isTimeUp = false;

                        // start the timer
                        qTimer.Start();

                        // prompt the question
                        Console.WriteLine(triviaToAsk.results[0].question);
                        Console.WriteLine(" ");

                        // give the answers in a random order
                        Random rand = new Random();
                        int randOrderM4 = rand.Next(0, 4);
                        int randOrderM2 = rand.Next(0, 2);
                        if (triviaToAsk.results[0].incorrect_answers.Count() == 3)
                        {
                            if (randOrderM4 == 0)
                            {
                                Console.WriteLine(triviaToAsk.results[0].correct_answer);
                                Console.WriteLine(triviaToAsk.results[0].incorrect_answers[0]);
                                Console.WriteLine(triviaToAsk.results[0].incorrect_answers[1]);
                                Console.WriteLine(triviaToAsk.results[0].incorrect_answers[2]);
                            }
                            else if (randOrderM4 == 1)
                            {
                                Console.WriteLine(triviaToAsk.results[0].incorrect_answers[0]);
                                Console.WriteLine(triviaToAsk.results[0].correct_answer);
                                Console.WriteLine(triviaToAsk.results[0].incorrect_answers[1]);
                                Console.WriteLine(triviaToAsk.results[0].incorrect_answers[2]);
                            }
                            else if (randOrderM4 == 2)
                            {
                                Console.WriteLine(triviaToAsk.results[0].incorrect_answers[0]);
                                Console.WriteLine(triviaToAsk.results[0].incorrect_answers[1]);
                                Console.WriteLine(triviaToAsk.results[0].correct_answer);
                                Console.WriteLine(triviaToAsk.results[0].incorrect_answers[2]);
                            }
                            else
                            {
                                Console.WriteLine(triviaToAsk.results[0].incorrect_answers[0]);
                                Console.WriteLine(triviaToAsk.results[0].incorrect_answers[1]);
                                Console.WriteLine(triviaToAsk.results[0].incorrect_answers[2]);
                                Console.WriteLine(triviaToAsk.results[0].correct_answer);
                            }
                        }
                        else
                        {
                            if (randOrderM2 == 0)
                            {
                                Console.WriteLine(triviaToAsk.results[0].correct_answer);
                                Console.WriteLine(triviaToAsk.results[0].incorrect_answers[0]);
                            }
                            else
                            {
                                Console.WriteLine(triviaToAsk.results[0].incorrect_answers[0]);
                                Console.WriteLine(triviaToAsk.results[0].correct_answer);
                            }
                        }

                        // tell the user to enter their answer
                        Console.WriteLine(" ");
                        Console.Write("Enter your answer here: ");
                        playerTriviaAnswer = Console.ReadLine();
                        Console.WriteLine(" ");

                        // stop the timer once the player has press enter
                        qTimer.Stop();

                        // if the timer has ran out, take away the wagered HP from the user and tell them their current HP
                        if (isTimeUp)
                        {
                            Console.WriteLine("\"I'll be taking your wager now...\"");
                            Console.WriteLine("You feel the energy being drained from your mortal coil.");
                            playerHealth -= nPlayerHPWager;
                            Console.WriteLine("Current Health: " + playerHealth);
                            Console.WriteLine(" ");
                        }
                        // check to see if the answer is correct when time has not ran out
                        else if (playerTriviaAnswer == triviaToAsk.results[0].correct_answer)
                        {
                            Console.WriteLine("\"Ah! You got it correct. Congratulations!\"");
                            Console.WriteLine("\"Here is your reward\"");
                            playerHealth += nPlayerHPWager;
                            Console.WriteLine("Current Health: " + playerHealth);
                            Console.WriteLine(" ");
                        }
                        else if (playerTriviaAnswer != triviaToAsk.results[0].correct_answer && !isTimeUp)
                        {
                            Console.WriteLine("\"INCORRECT!\"");
                            Console.WriteLine("\"I'll be taking what's mine.\"");
                            Console.WriteLine("You feel the energy being drained from your mortal coil.");
                            playerHealth -= nPlayerHPWager;
                            Console.WriteLine("Current Health: " + playerHealth);
                            Console.WriteLine(" ");
                        }
                    }
                }
                else if (playerGameChoice.ToLower().Equals("e"))
                {
                    // tell the user the exits available to them and prompt them for which exit they will choose
                    AvailableExits(ref currentRoom, ref playerHealth);
                    Console.WriteLine(" ");

                    // gets the neighbors and costs for the current room based on listGraph
                    (int, int)[] thisRoomNeighbors = listGraph[currentRoom];

                    while (!validExit)
                    {
                        Console.WriteLine("Which exit will you choose?");
                        Console.WriteLine("Enter the letter of the room you would like to travel to, or return to the current room (R)");
                        playerExitChoice = Console.ReadLine().ToUpper()[0].ToString();

                        // checks if the player has chosen to traverse to another room or return to the current room to do something else
                        if (!playerExitChoice.ToLower().Equals("r"))
                        {
                            // checks to see if a valid room option has been chosen
                            bool validRoom = false;
                            int costToMove = 0;

                            foreach ((int, int) neighbor in thisRoomNeighbors)
                            {
                                if ((playerExitChoice[0] - 'A') == neighbor.Item1 && (playerHealth - neighbor.Item2) > 0)
                                {
                                    validRoom = true;
                                    costToMove = neighbor.Item2;
                                    break;
                                }
                            }

                            if (validRoom)
                            {
                                // bool to check to see if the states match
                                bool equalStates = false;

                                if(stateList[playerExitChoice[0] - 'A'] == 1 && playerState == 3) 
                                {
                                    equalStates = true;
                                }
                                else if(stateList[playerExitChoice[0] - 'A'] == 3 && playerState == 1) 
                                {
                                    equalStates = true;
                                }
                                else if(stateList[playerExitChoice[0]- 'A'] == playerState) 
                                {
                                    equalStates = true;
                                }
                                else 
                                {
                                    equalStates = false;
                                }

                                lock (lockObject)
                                {
                                    if (equalStates)
                                    {
                                        // tell the user that they are losing HP by moving to the next room
                                        Console.WriteLine("You feel the energy escape your body as you traverse the threshold to the next room.");
                                        Console.WriteLine(" ");

                                        // reduce the player HP
                                        playerHealth -= costToMove;

                                        // move to the new room
                                        currentRoom = playerExitChoice[0] - 'A';

                                        // increment the move counter
                                        moveCounter++;

                                        // set validExit to true to escape the while loop
                                        validExit = true;

                                        break;
                                    }
                                    else 
                                    {
                                        Console.WriteLine("Sorry, your state does not match the state of the next room.");
                                        Console.WriteLine(" ");
                                        validExit = false;
                                    }
                                }
                            }

                            if (!validRoom)
                            {
                                Console.WriteLine("Sorry, that is not a valid direction.");
                                Console.WriteLine(" ");
                                validExit = false;
                            }

                        }
                        else
                        {
                            validExit = true;
                        }

                    }

                    // set validExit to false for the next time the player tries to exit
                    validExit = false;
                }
                else if (playerGameChoice.ToLower().Equals("c"))
                {
                    // check to see if changing states will reduce the player's health to 0
                    if ((playerHealth - 1) <= 0)
                    {
                        Console.WriteLine("Sorry! It costs 1 HP to change state and you don't have enough to do so.");
                    }
                    else
                    {
                        if (playerState == (int)NodeState.ice)
                        {
                            playerState = (int)NodeState.liquid_gas;
                            playerHealth--;
                        }
                        else if (playerState == (int)NodeState.liquid_gas)
                        {
                            playerState = (int)NodeState.gas;
                            playerHealth--;
                        }
                        else if (playerState == (int)NodeState.gas)
                        {
                            playerState = (int)NodeState.liquid_ice;
                            playerHealth--;
                        }
                        else if (playerState == (int)NodeState.liquid_ice)
                        {
                            playerState = (int)NodeState.ice;
                            playerHealth--;
                        }
                    }
                }

                // if the player's health is equal to or below 0, the game ends
                if (playerHealth <= 0)
                {
                    Console.WriteLine("Well now, it looks like you have no more life to wager.");
                    Console.WriteLine("Truly a shame you couldn't escape.");
                    Console.WriteLine("I guess I'll be seeing you around.");
                    Console.WriteLine(" ");
                    isAlive = false;
                }
            }
        }

        // Method: RoomDescription
        // Purpose: Prints to the console the description of the current room
        // Restrictions: None
        public static void RoomDescription(ref int currentRoom)
        {
            // A
            if (currentRoom == 0)
            {
                Console.WriteLine("Room A");
                Console.WriteLine("The entrance to the labrynth is decayed, with an abundace of moss covering most of the rough stone walls.");
                Console.WriteLine("The columns of marble have worn away with time, and a mirror sits on the right wall.");
                Console.WriteLine("You look at yourself, bright eyed and ready to tackle the challenge ahead.");
                Console.WriteLine(" ");
            }
            // B
            else if (currentRoom == 1)
            {
                Console.WriteLine("Room B");
                Console.WriteLine("Scratch marks adorn the aged walls.");
                Console.WriteLine("A high pitched whine echoes equally around the room.");
                Console.WriteLine("Turning to look at each wall, you swear some of those scratches weren't there when you first entered.");
                Console.WriteLine(" ");
            }
            // C
            else if (currentRoom == 2)
            {
                Console.WriteLine("Room C");
                Console.WriteLine("A large statue sits in the middle of the room, missing its head and right arm.");
                Console.WriteLine("A plaque was imprinted into the stone at the base of the statue, but the words are too weathered to read.");
                Console.WriteLine("You feel another presence in this room, but no one to be found except for the statue and yourself.");
                Console.WriteLine(" ");
            }
            // D
            else if (currentRoom == 3)
            {
                Console.WriteLine("Room D");
                Console.WriteLine("Several silver platters sit on tall tabels dressed in white.");
                Console.WriteLine("You hear your stomach growl once the scent of food presses into your nose.");
                Console.WriteLine("Uncovering the platters you find nothing but dissapointment in the emptiness of the room and your stomach.");
                Console.WriteLine(" ");
            }
            // E
            else if (currentRoom == 4)
            {
                Console.WriteLine("Room E");
                Console.WriteLine("You feel crushed as the ceiling seems to narrow towards you the farther you walk in.");
                Console.WriteLine("Turning around you hope to return to stand at a more comfortable height.");
                Console.WriteLine("Alas, you find that the ceiling has adjusted itself to be at the height at which you are currently crouched.");
                Console.WriteLine(" ");
            }
            // F
            else if (currentRoom == 5)
            {
                Console.WriteLine("Room F");
                Console.WriteLine("Large footprints create craters in the floor.");
                Console.WriteLine("You would think nothing of it, but these craters seem to be at least twice the size of your foot size.");
                Console.WriteLine("You hear foot steps coming from the direction you entered.");
                Console.WriteLine(" ");
            }
            // G
            else if (currentRoom == 6)
            {
                Console.WriteLine("Room G");
                Console.WriteLine("Stakes and tombstones fill the room from wall to wall.");
                Console.WriteLine("None are named, but you know these must be of adventurers who have walked this path before you.");
                Console.WriteLine("There is one stone unmarked, the hole in the ground perfectly matching your height.");
                Console.WriteLine(" ");
            }
            //H
            else
            {
                Console.WriteLine("Room H");
                Console.WriteLine("Congratulations!");
                Console.WriteLine("Through the final passage you pass the threshold, catching your breath.");
                Console.WriteLine("You look at yourself in the mirror on the wall, seeing the energy drained from your eyes.");
                Console.WriteLine("Maybe you will find something else to do next weekend.");
                Console.WriteLine(" ");
            }

        }

        // Method: AvailableExits
        // Purpose: Checks the current room of the player and tells them the available exits
        // Restrictions: None
        public static void AvailableExits(ref int currentRoom, ref int playerHealth)
        {
            // get an array of ints of available rooms to exit to given the current room
            int[] availableExits = lGraph[currentRoom];

            // prints the available exits to travel to given the player's current HP
            for (int i = 0; i < availableExits.Length; i++)
            {
                // prints the available room if moving to that room will not reduce the player's HP below zero
                if ((playerHealth - wGraph[currentRoom][i]) > 0)
                {
                    Console.WriteLine("There is an exit to room " + NumToRoom(availableExits[i]) + " that will cost you " + wGraph[currentRoom][i] + " HP to travel to.");
                }
            }
        }

        // Method: NumToRoom
        // Purpose: Changes the number from the adjacency list to the letter of the room
        // Restrictions: None
        public static string NumToRoom(int roomNumber)
        {
            if (roomNumber == 0)
            {
                return "A";
            }
            else if (roomNumber == 1)
            {
                return "B";
            }
            else if (roomNumber == 2)
            {
                return "C";
            }
            else if (roomNumber == 3)
            {
                return "D";
            }
            else if (roomNumber == 4)
            {
                return "E";
            }
            else if (roomNumber == 5)
            {
                return "F";
            }
            else if (roomNumber == 6)
            {
                return "G";
            }
            else if (roomNumber == 7)
            {
                return "H";
            }
            else
            {
                return "How did you even get here?";
            }

        }

        // Method: AskTrivia
        // Purpose: Used to get a trivia question from the API and create a Trivia object to be used to ask the question
        // Restrictions: None
        public static Trivia AskTrivia()
        {
            string url = null;
            string s = null;

            HttpWebRequest request;
            HttpWebResponse response;
            StreamReader reader;

            url = "https://opentdb.com/api.php?amount=1";

            request = (HttpWebRequest)WebRequest.Create(url);
            response = (HttpWebResponse)request.GetResponse();
            reader = new StreamReader(response.GetResponseStream());
            s = reader.ReadToEnd();
            reader.Close();

            Trivia trivia = JsonConvert.DeserializeObject<Trivia>(s);

            trivia.results[0].question = HttpUtility.HtmlDecode(trivia.results[0].question);
            trivia.results[0].correct_answer = HttpUtility.HtmlDecode(trivia.results[0].correct_answer);
            for (int i = 0; i < trivia.results[0].incorrect_answers.Count; ++i)
            {
                trivia.results[0].incorrect_answers[i] = HttpUtility.HtmlDecode(trivia.results[0].incorrect_answers[i]);
            }

            return trivia;
        }

        // Method: OutOfTime
        // Purpose: Event that occurs when the 15 seconds are up for the trivia question
        // Restrictions: None
        private static void OutOfTime(Object source, ElapsedEventArgs e)
        {
            // tell the user that their time is up
            Console.WriteLine(" ");
            Console.WriteLine("Your time is up!");
            Console.WriteLine("Please press enter!");

            // set the isTimeUp bool to true
            isTimeUp = true;

            // stop the timer
            qTimer.Stop();
        }

        // Method: ChangeNodeStates
        // Purpose: Changes the states of the rooms every second
        // Restrictions: None
        static void ChangeNodeStates(object sender, ElapsedEventArgs e)
        {
            lock (lockObject)
            {
                for (int i = 0; i < stateList.Length; ++i)
                {
                    if (stateList[i] == (int)NodeState.ice)
                    {
                        stateList[i] = (int)NodeState.liquid_gas;
                    }
                    else if (stateList[i] == (int)NodeState.liquid_gas)
                    {
                        stateList[i] = (int)NodeState.gas;
                    }
                    else if (stateList[i] == (int)NodeState.gas)
                    {
                        stateList[i] = (int)NodeState.liquid_ice;
                    }
                    else if (stateList[i] == (int)NodeState.liquid_ice)
                    {
                        stateList[i] = (int)NodeState.ice;
                    }
                }

                // increment the time counter
                timeCounter++;
            }
        }
    }
}
