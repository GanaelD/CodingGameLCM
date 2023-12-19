static void Draft(List<Card> draft)
    {
        Console.Error.WriteLine("draft");
        if(draft==null)
        {
            Console.Error.WriteLine("draft empty");
        }
        else
        {
            int cost = 30;
            int indexChoice = 0;

            for(int i = 0; i<3; i++)
            {
                if (draft[i].cost>7)
                {
                    draft[i].cost = 7;
                }
                if(Player.curve[draft[i].cost]<cost)
                {
                    cost = Player.curve[draft[i].cost];
                    indexChoice = i;
                }
            }
            Player.PickCard(indexChoice);
            if(cost>7)
            {
                cost = 7;
            }
            Player.curve[draft[indexChoice].cost] += 1;
            //Console.Error.WriteLine(cost + " : " + Player.curve[cost]);
        }

    }
