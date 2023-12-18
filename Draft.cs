static void Draft(List<Card> draft)
    {
        Console.Error.WriteLine("draft");
        if(draft==null)
        {
            Console.Error.WriteLine("draft empty");
        }
        else
        {
            int cost = draft[0].cost;
            int indexChoice = 0;
            for(int i = 0; i<3; i++)
            {
                if(draft[i].cost<cost)
                {
                    cost = draft[i].cost;
                    indexChoice = i;
                }
            }
            Player.PickCard(indexChoice);
        }

    }
