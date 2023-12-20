static void Main(string[] args)
    {
        string[] inputs;

        // game loop
        while (true)
        {
            int mana = 0;
            hand.Clear();
            myBoard.Clear();
            hisBoard.Clear();
            actions = "";
            for (int i = 0; i < 2; i++)
            {
                inputs = Console.ReadLine().Split(' ');
                int playerHealth = int.Parse(inputs[0]);
                int playerMana = int.Parse(inputs[1]);
                mana = i == 0 ? int.Parse(inputs[1]) : mana;
                int playerDeck = int.Parse(inputs[2]);
                int playerRune = int.Parse(inputs[3]);
                int playerDraw = int.Parse(inputs[4]);
            }
            inputs = Console.ReadLine().Split(' ');
            int opponentHand = int.Parse(inputs[0]);
            int opponentActions = int.Parse(inputs[1]);
            for (int i = 0; i < opponentActions; i++)
            {
                string cardNumberAndAction = Console.ReadLine();
            }
            int cardCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < cardCount; i++)
            {
                inputs = Console.ReadLine().Split(' ');
                int cardNumber = int.Parse(inputs[0]);
                int instanceId = int.Parse(inputs[1]);
                int location = int.Parse(inputs[2]);
                int cardType = int.Parse(inputs[3]);
                int cost = int.Parse(inputs[4]);
                int attack = int.Parse(inputs[5]);
                int defense = int.Parse(inputs[6]);
                string abilities = inputs[7];
                int myHealthChange = int.Parse(inputs[8]);
                int opponentHealthChange = int.Parse(inputs[9]);
                int cardDraw = int.Parse(inputs[10]);
                Card card = new Card(cardNumber, instanceId, location, cardType, cost, attack, defense, abilities);
                if (card.location==0)
                {
                    hand.Add(card);
                } else if (location==1)
                {
                    myBoard.Add(card);
                    attackers.Add(card);
                } else 
                {
                    hisBoard.Add(card);
                }
            }

            // Write an action using Console.WriteLine()
            // To debug: Console.Error.WriteLine("Debug messages...");

            if(mana==0){
                Console.Error.WriteLine("draft if");
                Draft(hand);
            }else{
                Summon(mana);
                if(myBoard.Count>0)
                {
                    Fight();
                }            
            }
            if(actions == ""){
                Console.WriteLine("PASS");
            } else {
                Console.WriteLine(actions);
            }
            Console.Error.WriteLine("end Turn");
        }
    }
