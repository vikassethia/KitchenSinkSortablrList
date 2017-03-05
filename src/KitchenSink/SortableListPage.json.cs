using Starcounter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Starcounter.Templates;

namespace KitchenSink
{
    [Database]
    public class People
    {
        public int Id;
        public string FirstName;
        public string LastTime;
        public int SortOrder;
        public bool IsFirst;
        public bool IsLast;

    }

    partial class SortableListPage : Json
    {
        protected override void OnData()
        {
            base.OnData();

            UpdateData();
        }

        private void UpdateData()
        {
            Peoples.Clear();
            Peoples.Data = GetPeoplesFromDatabae();
            Peoples.AutoRefreshBoundProperties = true;
        }

        private List<People> GetPeoplesFromDatabae()
        {
            var dbList = Db.SQL<People>("SELECT p FROM People p").ToList();
            dbList =  dbList.OrderBy(p => p.SortOrder).ToList();
            return dbList;
        } 

        public void Down(People people)
        {
            var itemSortOrder = people.SortOrder;
            var downSorOrder = itemSortOrder + 1;

            var selectedPeople = Db.SQL<People>("SELECT i FROM People i WHERE SortOrder = ?", itemSortOrder).First;

            var downPeople = Db.SQL<People>("SELECT i FROM People i WHERE SortOrder = ?", downSorOrder).First;

            Db.Transact(delegate ()
            {
                selectedPeople.SortOrder = downSorOrder;
                downPeople.SortOrder = itemSortOrder;
                if (downPeople.IsLast)
                {
                    downPeople.IsLast = false;
                    selectedPeople.IsLast = true;
                }
                if (selectedPeople.IsFirst)
                {
                    downPeople.IsFirst = true;
                    selectedPeople.IsFirst = false;
                }
            });
            OnData();
        }
        public void Up(People people)
        {
            var itemSortOrder = people.SortOrder;
            var upSorOrder = itemSortOrder - 1;

            var selectedPeople = Db.SQL<People>("SELECT i FROM People i WHERE SortOrder = ?", itemSortOrder).First;

            var upPeople = Db.SQL<People>("SELECT i FROM People i WHERE SortOrder = ?", upSorOrder).First;

            Db.Transact(delegate ()
            {
                selectedPeople.SortOrder = upSorOrder;
                upPeople.SortOrder = itemSortOrder;
                if (upPeople.IsFirst)
                {
                    upPeople.IsFirst = false;
                    selectedPeople.IsFirst=true;
                }
                if (selectedPeople.IsLast)
                {
                    upPeople.IsLast = true;
                    selectedPeople.IsLast = false;
                }
            });
            OnData();
        }
    }

    [SortableListPage_json.Peoples]
    partial class SortableListPagePeoplesElement : Json, IBound<People>
    {
       void Handle(Input.Up action)
        {

            if (Data != null)
            {
                SortableListPage sortableList = new SortableListPage();
                sortableList.Up(Data);
            }
        }

        void Handle(Input.Down action)
        {
            if (Data != null)
            {
                SortableListPage sortableList = new SortableListPage();
                sortableList.Down(Data);
            }
        }
    }

}