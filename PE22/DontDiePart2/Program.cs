using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;
using System.IO;
using System.Net;
using System.Web;

namespace DontDiePart2
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

    // Class: Project
    // Author: Ajay Ramnarine
    // Purpose: Create the Don't Die game as described in PE22, using the adjacency matrix or list created in PE21
    // Restrictions: None
    class Program
    {
        // set up a timer to be used for the trivia questions
        private static System.Timers.Timer timer;

        // bool to check if the timer has elapsed
        static bool isTimeUp = false;

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
            /*A*/   {     0,      2,     -1,     -1,     -1,     -1,     -1,     -1 },
            /*B*/   {    -1,     -1,      2,      3,     -1,     -1,     -1,     -1 },
            /*C*/   {    -1,      2,     -1,     -1,     -1,     -1,     -1,     20 },
            /*D*/   {    -1,      3,      5,     -1,      2,      4,     -1,     -1 },
            /*E*/   {    -1,     -1,     -1,     -1,     -1,      3,     -1,     -1 },
            /*F*/   {    -1,     -1,     -1,     -1,     -1,     -1,      1,     -1 },
            /*G*/   {    -1,     -1,     -1,     -1,      0,     -1,     -1,      2 },
            /*H*/   {    -1,     -1,     -1,     -1,     -1,     -1,     -1,     -1 }
        };

        static string[,] mdGraph = new string[,]
        {
                        /*A*/   /*B*/   /*C*/   /*D*/   /*E*/   /*F*/   /*G*/   /*H*/
            /*A*/   {   "N,E",   "S",   null,   null,   null,   null,   null,   null },
            /*B*/   {   null,   null,    "S",    "E",   null,   null,   null,   null },
            /*C*/   {   null,    "N",   null,   null,   null,   null,   null,    "S" },
            /*D*/   {   null,    "W",    "S",   null,    "N",    "E",   null,   null },
            /*E*/   {   null,   null,   null,   null,   null,    "S",   null,   null },
            /*F*/   {   null,   null,   null,   null,   null,   null,    "E",   null },
            /*G*/   {   null,   null,   null,   null,    "N",   null,   null,    "S" },
            /*H*/   {   null,   null,   null,   null,   null,   null,   null,   null }
        };

        // Adjacency List
        // Written as 2 parallel lists
        // The first list will represent the rooms (or nodes) as well as what rooms can be traveled to from said rooms
        // The order of the lists will be North, South, East, and then West
        // A value of -1 means that travel is not possible through that direction
        // The rooms will be represented through numbers (A=0, B=1, C=2, D=3, E=4, F=5, G=6, and H=7)
        // The second list will represent the cost it takes to travel between the rooms
        // As the lists are parallel, the costs in the second list will correspond to the rooms that can be traveled to in the first list
        static int[][] lGraph = new int[][]
        {
            /*A*/ new int[] {0, 1, 0, -1},
            /*B*/ new int[] {-1, 2, 3, -1},
            /*C*/ new int[] {1, 7, -1, -1},
            /*D*/ new int[] {4, 2, 5, 1},
            /*E*/ new int[] {-1, 5, -1, -1},
            /*F*/ new int[] {-1, -1, 6, -1},
            /*G*/ new int[] {4, 7, -1, -1},
            /*H*/ null
        };

        static int[][] wGraph = new int[][]
        {
            /*A*/ new int[] {0, 2, 0, -1},
            /*B*/ new int[] {-1, 2, 3, -1},
            /*C*/ new int[] {2, 20, -1, -1},
            /*D*/ new int[] {2, 5, 4, 3},
            /*E*/ new int[] {-1, 3, -1, -1},
            /*F*/ new int[] {-1, -1, 1, -1},
            /*G*/ new int[] {0, 2, -1, -1},
            /*H*/ null
        };

        // Method: Main
        // Purpose: Create the Don't Die game using the adjacency matrix or list, and the trivia class to ask the player questions
        //          The player should be able to navigate from "room" to "room" or be able to wager their HP through trivia
        //          Player will only have 15 seconds to answer trivia questions or they will lose the HP
        //          They start at point A (0) and need to get to point H(7)
        //          If the player's HP is equal to or below 0, they lose
        // Restrictions: None
        static void Main(string[] args)
        {
            // create a timer with a 15 second interval
            timer = new System.Timers.Timer();
            timer.Interval = 15000;

            // attach an elapsed event for the timer
            timer.Elapsed += OnTimedEvent;

            // player HP and HP wager
            int playerHealth = 1;
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

            // used to check if the player is changing rooms or backing out of looking for exits/trivia
            int occupiedRoom = 0;

            // while the player is alive, loop through the game elements
            while (isAlive)
            {
                if (currentRoom != occupiedRoom)
                {
                    // Drop the player's hp due to the change in room
                    HealthDrop(ref currentRoom, ref playerHealth);

                    // set the occupiedRoom to the currentRoom the player is in
                    occupiedRoom = currentRoom;
                }
                // Print the current HP of the player
                Console.WriteLine("Current Health: " + playerHealth);
                Console.WriteLine(" ");

                // Check to see which room the player is currently in, and print a description of the room and available doors to exit from
                RoomDescription(ref currentRoom);

                if(currentRoom == 7) 
                {
                    Console.WriteLine("Thank you for playing!");
                    break;
                }
                else 
                {
                    // prompt the user for trivia or to ask if they would like to look for an exit
                    Console.WriteLine("A skull sits in the center of the room.");
                    Console.WriteLine("A red plus sign surrounded by a large \"Q\" is inscribed on the forehead.");

                    // checks the validity of the input of the player's choice
                    do {
                        Console.WriteLine("Do you approach the skull(S), or do you look for an exit(E)?");
                        playerGameChoice = Console.ReadLine();

                        if(playerGameChoice.ToLower().Equals("s") || playerGameChoice.ToLower().Equals("e")) 
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
                        timer.Start();

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
                        timer.Stop();

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
                else if(playerGameChoice.ToLower().Equals("e")) 
                {
                    // tell the user the exits available to them and prompt them for which exit they will choose
                    AvailableExits(ref currentRoom, ref playerHealth);
                    Console.WriteLine(" ");

                    while (!validExit)
                    {
                        Console.WriteLine("Which exit will you choose?");
                        Console.WriteLine("North(N), South(S), East(E), or West(W)?");
                        Console.WriteLine("Go Back (B)");
                        playerExitChoice = Console.ReadLine();

                        // Player chooses North (N)
                        if (playerExitChoice.ToLower().Equals("n"))
                        {
                            if (lGraph[currentRoom][0] == -1 || (playerHealth - wGraph[currentRoom][0]) <= 0)
                            {
                                Console.WriteLine("Sorry, that is not an available option.");
                                Console.WriteLine(" ");
                                validExit = false;
                            }
                            else
                            {
                                // tell the user that they are losing HP by traveling from room to room
                                Console.WriteLine("You feel the energy escaping your body as your traverse the threshold of the door.");
                                Console.WriteLine(" ");

                                // take away HP from the player based on wGraph (the list parallel to lGraph)
                                playerHealth -= wGraph[currentRoom][0];

                                // move the player to another room based on the adjacency list
                                currentRoom = lGraph[currentRoom][0];

                                // set validExit to true to escape the loop
                                validExit = true;
                            }
                        }
                        // Player chooses South (S)
                        else if (playerExitChoice.ToLower().Equals("s"))
                        {
                            if (lGraph[currentRoom][1] == -1 || (playerHealth - wGraph[currentRoom][1]) <= 0)
                            {
                                Console.WriteLine("Sorry, that is not an available option.");
                                Console.WriteLine(" ");
                                validExit = false;
                            }
                            else
                            {
                                // tell the user that they are losing HP by traveling from room to room
                                Console.WriteLine("You feel the energy escaping your body as your traverse the threshold of the door.");
                                Console.WriteLine(" ");

                                // take away HP from the player based on wGraph (the list parallel to lGraph)
                                playerHealth -= wGraph[currentRoom][1];

                                // move the player to another room based on the adjacency list
                                currentRoom = lGraph[currentRoom][1];

                                // set validExit to true to escape the loop
                                validExit = true;
                            }
                        }
                        // Player chooses East (E)
                        else if (playerExitChoice.ToLower().Equals("e"))
                        {
                            if (lGraph[currentRoom][2] == -1 || (playerHealth - wGraph[currentRoom][2]) <= 0)
                            {
                                Console.WriteLine("Sorry, that is not an available option.");
                                Console.WriteLine(" ");
                                validExit = false;
                            }
                            else
                            {
                                // tell the user that they are losing HP by traveling from room to room
                                Console.WriteLine("You feel the energy escaping your body as your traverse the threshold of the door.");
                                Console.WriteLine(" ");

                                // take away HP from the player based on wGraph (the list parallel to lGraph)
                                playerHealth -= wGraph[currentRoom][2];

                                // move the player to another room based on the adjacency list
                                currentRoom = lGraph[currentRoom][2];

                                // set validExit to true to escape the loop
                                validExit = true;
                            }
                        }
                        // Player chooses West (W)
                        else if (playerExitChoice.ToLower().Equals("w"))
                        {
                            if (lGraph[currentRoom][3] == -1 || (playerHealth - wGraph[currentRoom][3]) <= 0)
                            {
                                Console.WriteLine("Sorry, that is not an available option.");
                                Console.WriteLine(" ");
                                validExit = false;
                            }
                            else
                            {
                                // tell the user that they are losing HP by traveling from room to room
                                Console.WriteLine("You feel the energy escaping your body as your traverse the threshold of the door.");
                                Console.WriteLine(" ");

                                // take away HP from the player based on wGraph (the list parallel to lGraph)
                                playerHealth -= wGraph[currentRoom][3];

                                // move the player to another room based on the adjacency list
                                currentRoom = lGraph[currentRoom][3];

                                // set validExit to true to escape the loop
                                validExit = true;
                            }
                        }
                        // check to see if the player wants to go back for trivia before they leave the room, or if they can't leave the room yet
                        else if (playerExitChoice.ToLower().Equals("b")) 
                        {
                            validExit = true;
                        }
                        else 
                        {
                            Console.WriteLine("Sorry, that is not an available option.");
                            Console.WriteLine(" ");
                            validExit = false;
                        }
                    }

                    // set validExit to false for the next time the player tries to exit
                    validExit = false;
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

        // Method: HealthDrop
        // Purpose: Drop the player's health a random amount, but never below 1
        //          Unless the player is in room A(0) or room H(7), then don't drop their health
        // Restrictions: None
        public static void HealthDrop(ref int currentRoom, ref int playerHealth) 
        { 
            // check to see if the user is not in room A or room H
            if(currentRoom == 0 || currentRoom == 7) 
            {
            }
            else 
            {
                // randomly generate a number
                Random rand = new Random();
                int healthDrop = rand.Next(0, 10);

                while((playerHealth - healthDrop) <= 0) 
                {
                    healthDrop = rand.Next(0, 10);
                }

                // reduce the players health by the random number
                playerHealth -= healthDrop;

                // random lines to explain the damage to the player
                if(healthDrop == 1) 
                {
                    Console.WriteLine("You trip, and hit your shoulder into the side of the wall.");
                    Console.WriteLine(" ");
                }
                else if(healthDrop == 2) 
                {
                    Console.WriteLine("You stub your toe on the corner of the door frame. Ouch!");
                    Console.WriteLine(" ");
                }
                else if(healthDrop == 3) 
                {
                    Console.WriteLine("Oh no! Charlie Horse! You take some time to deal with the pain in your calf.");
                    Console.WriteLine(" ");
                }
                else if(healthDrop == 4) 
                {
                    Console.WriteLine("AH! You hit your knee on the side of a random table. Was that even there before?");
                    Console.WriteLine(" ");
                }
                else if(healthDrop == 5) 
                {
                    Console.WriteLine("Oooo, not sure if eating that burrito before coming here was a good idea...");
                    Console.WriteLine(" ");
                }
                else if(healthDrop == 6) 
                {
                    Console.WriteLine("A bat flies into your face, startling both you and it. Make sure to check for rabies later.");
                    Console.WriteLine(" ");
                }
                else if(healthDrop == 7) 
                {
                    Console.WriteLine("You unexpectedly fall flat onto your face. You weren't fast enough to catch your fall. ");
                    Console.WriteLine(" ");
                }
                else if(healthDrop == 8) 
                {
                    Console.WriteLine("The door slams onto your finger. Gonna need some bandages for that later.");
                    Console.WriteLine(" ");
                }
                else if(healthDrop == 9) 
                {
                    Console.WriteLine("You remember that embarassing thing you did years ago. That's going to stick with you for a while longer.");
                    Console.WriteLine(" ");
                } 
            }
        }

        // Method: RoomDescription
        // Purpose: Prints to the console the description of the current room
        // Restrictions: None
        public static void RoomDescription(ref int currentRoom) 
        { 
            // A
            if(currentRoom == 0) 
            {
                Console.WriteLine("You find yourself in a dark, musty attic.");
                Console.WriteLine("A single lightbulb held by a string flickers above your head.");
                Console.WriteLine("Empty cardboard boxes are strewn about the room.");
                Console.WriteLine(" ");
            }
            // B
            else if(currentRoom == 1) 
            {
                Console.WriteLine("You enter a ballroom, dim and decrepit.");
                Console.WriteLine("A strange waltz plays low and slow, seemingly without a source.");
                Console.WriteLine("The windows in the room stretch to the ceiling, as do the finger prints staining their glass.");
                Console.WriteLine(" ");
            }
            // C
            else if(currentRoom == 2) 
            {
                Console.WriteLine("A courtyard stretches out in front of you, encased by the empty manor.");
                Console.WriteLine("Eerily, the fountain in the center seems to be running in reverse.");
                Console.WriteLine("Nature has begun to reclaim most of the structures and benches spattered about the area.");
                Console.WriteLine(" ");
            }
            // D
            else if(currentRoom == 3) 
            {
                Console.WriteLine("Deliriously, you stumble into a dining room.");
                Console.WriteLine("A long table expands through the middle of the room, from wall to wall, adorned with unlit candles.");
                Console.WriteLine("A glass chandelier looms above the room, reflecting light that doesn't seem to be present.");
                Console.WriteLine(" ");
            }
            // E
            else if(currentRoom == 4) 
            {
                Console.WriteLine("Electrical wiring runs through this room, seemingly slithering through the ceiling and floors.");
                Console.WriteLine("A large box sits on a wall, rusted shut and emitting a low buzz.");
                Console.WriteLine("The wooden floor seems singed, and the roughly plastered ceiling drops dust ever so slowly.");
                Console.WriteLine(" ");
            }
            // F
            else if(currentRoom == 5) 
            {
                Console.WriteLine("Entering into the foyer of the manor would be exciting if it were not so empty.");
                Console.WriteLine("Your voice echoes endlessly, but you swear you can hear another response every so often.");
                Console.WriteLine("The sounds of footsteps click and clack along the broken pattern of the marble floor.");
                Console.WriteLine(" ");
            }
            // G
            else if(currentRoom == 6) 
            {
                Console.WriteLine("The garage is cluttered with empty toolboxes and broken down cars.");
                Console.WriteLine("With junk laying ankle high, the atmosphere becomes claustrophobic as you feel yourself getting closer to the ceiling.");
                Console.WriteLine("A fire hazard would be putting it lightly, so don't light a match.");
                Console.WriteLine(" ");
            }
            //H
            else 
            {
                Console.WriteLine("You've made it out alive.");
                Console.WriteLine("Congratulations!");
                Console.WriteLine("Through the final door, you enter your home, being wary of the door in your attic that started this all.");
            }
        
        }

        // Method: AvailableExits
        // Purpose: Checks the current room of the player and tells them the available exits
        // Restrictions: None
        public static void AvailableExits(ref int currentRoom, ref int playerHealth) 
        {
            // get an array of ints of available rooms given the current room
            int[] availableExits = lGraph[currentRoom];

            // If the player is able to travel North
            if(availableExits[0] != -1 && (playerHealth - wGraph[currentRoom][0]) > 0) 
            {
                Console.WriteLine("There is a door to the North.");
            }

            // If the player is able to travel South
            if (availableExits[1] != -1 && (playerHealth - wGraph[currentRoom][1]) > 0)
            {
                Console.WriteLine("There is a door to the South.");
            }

            // If the player is able to travel East
            if (availableExits[2] != -1 && (playerHealth - wGraph[currentRoom][2]) > 0)
            {
                Console.WriteLine("There is a door to the East.");
            }

            // If the player is able to travel West
            if (availableExits[3] != -1 && (playerHealth - wGraph[currentRoom][3]) > 0)
            {
                Console.WriteLine("There is a door to the West.");
            }
        }

        // Method: OnTimedEvent
        // Purpose: Event that occurs when the 15 seconds are up for the trivia question
        // Restrictions: None
        private static void OnTimedEvent(Object source, System.Timers.ElapsedEventArgs e) 
        {
            // tell the user that their time is up
            Console.WriteLine(" ");
            Console.WriteLine("Your time is up!");
            Console.WriteLine("Please press enter!");

            // set the isTimeUp bool to true
            isTimeUp = true;

            // stop the timer
            timer.Stop();
        }
    }
}
