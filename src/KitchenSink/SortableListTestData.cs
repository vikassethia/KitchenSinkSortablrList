using Starcounter;

/*
Test data hierarchy:

Products
    Food
        Dairy
            Milk
                Coffee milk 5 ML
                Milk 1 L
        Meat
    Metal
        Screws
            Phillips flat head
*/

namespace KitchenSink
{
    static class SortableListTestData
    {
        public static bool Exists()
        {
            var exists = Db.SQL<People>("SELECT p FROM People p FETCH ?", 1).First;
            if (exists == null)
            {
                return false;
            }
            return true;
        }

        public static void DeleteAll()
        {
            Db.SlowSQL("DELETE FROM People");
        }

        public static void Create()
        {
            Db.Transact(() =>
            {
                var Robert = new People()
                {
                    Id = 1,
                    FirstName = "Robert",
                    LastTime = "Jhonsson",
                    SortOrder = 0,
                    IsFirst = true,
                    IsLast = false
                };

                var Jhon = new People()
                {
                    Id = 2,
                    FirstName = "Jhon",
                    LastTime = "Anders",
                    SortOrder = 1,
                    IsFirst = false,
                    IsLast = false
                };

                var Fredrik = new People()
                {
                    Id = 3,
                    FirstName = "Fredrik",
                    LastTime = "Jonsson",
                    SortOrder = 2,
                    IsFirst = false,
                    IsLast = false
                };

                var Nils = new People()
                {
                    Id = 4,
                    FirstName = "Nils",
                    LastTime = "Andersson",
                    SortOrder = 3,
                    IsFirst = false,
                    IsLast = false
                };

                var Rohit = new People()
                {
                    Id = 5,
                    FirstName = "Rohit",
                    LastTime = "Sharma",
                    SortOrder = 4,
                    IsFirst = false,
                    IsLast = false
                };

                var Brett = new People()
                {
                    Id = 6,
                    FirstName = "Brett",
                    LastTime = "Lee",
                    SortOrder = 5,
                    IsFirst = false,
                    IsLast = true
                };

              
            });
        }
    }
}