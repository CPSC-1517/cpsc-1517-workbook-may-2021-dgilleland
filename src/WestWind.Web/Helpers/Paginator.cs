using System;
using System.Collections;
using System.Collections.Generic;

namespace WebApp.Helpers
{
    public record PageState(int CurrentPage, int PageSize);
    public record PageRef(int Page, string Text);
    
    public class Paginator : IEnumerable<PageRef>
    {
#region Obsolete
        [Obsolete("")] // adding these as needed to guide my "migration" from the old version to the new version
        public Paginator(int totalResults, int pageSize = 10, int maxPageLinks = 10)
        {
            // TODO: Do some validation....
            TotalResults = totalResults;
            PageSize = pageSize;
            MaxPageLinks = maxPageLinks;
        }

        ///<summary>Current is the human-friendly page number that is currently being displayed</summary>
        public int Current { get; set; }
        ///<summary>NextPage is the human-friendly page number for the next available page</summary>
        public int NextPage { get { return Current < LastPage ? Current + 1 : LastPage; } }
        ///<summary>PreviousPage is the human-friendly page number for the next available page</summary>
        public int PreviousPage { get { return Current > FirstPage ? Current - 1 : FirstPage; } }

        ///<summary>NextPage is the human-friendly page number for the next available page</summary>
        public int FirstPage { get { return 1; } }
        ///<summary>PreviousPage is the human-friendly page number for the next available page</summary>
        public int LastPage { get { return PageCount; } }


        ///<summary>PageSize is the number of items to display on each page</summary>
        public int PageSize { get; set; }


        ///<summary>MaxPageLinks is the number of links to generate</summary>
        public int MaxPageLinks { get; set; }
        ///<summary>FirstPageLink is the first page number in the set of Page Links</summary>
        public int FirstPageLink
        {
            get
            {
                int first = Current;
                int calculatedFirst = (LastPage - MaxPageLinks + 1);
                if (first > calculatedFirst && calculatedFirst >= Current)
                    first = calculatedFirst;
                return first;
            }
        }
        ///<summary>LastPageLink is the last page number in the set of Page Links</summary>
        public int LastPageLink
        {
            get
            {
                int last = FirstPageLink + MaxPageLinks - 1;
                if (last < FirstPage)
                    last = FirstPage;
                // If the calculated last page link is greater than the page count
                if (last > LastPage)
                    last = LastPage;
                return last;
            }
        }


        ///<summary>TotalResults is the total number of items in the pagination</summary>
        public int TotalResults { get; set; } = 7777;
        ///<summary>PageCount is the total number of pages for the TotalResults</summary>
        public int PageCount { get { return (TotalResults / PageSize) + 1; } }
        ///<summary>PageIndex is the computer-friendly "current page" (useful for calculations with zero-based indexes)</summary>
        public int PageIndex { get { return Current - 1; } }
        ///<summary>FromIndex is the human-friendly item number for the first item in the current page's results</summary>
        public int FromItem // The item # for the first
        {
            get
            {
                int offset = PageIndex * PageSize;
                return offset + 1;
            }
        }
        ///<summary>ToItem is the human-friendly item number for the last item in the current pages' results</summary>
        public int ToItem
        { get { return FromItem + PageSize - 1; } }
#endregion

        public readonly int TotalItemCount;
        public readonly PageState CurrentState;
        private List<PageRef> PageReferences;
        public string FirstPageText = "<First>";
        public string LastPageText = "<Last>";
        public string NextPageText = "<Next>";
        public string PreviousPageText = "<Prev>";

        public Paginator(int totalItemCount, PageState currentState)
        {
            TotalItemCount = totalItemCount;
            CurrentState = currentState;
            PageReferences = new List<PageRef>();
            PageReferences.Add(new(FirstPage, FirstPageText));
            PageReferences.Add(new(FirstPage, PreviousPageText)); // TODO: Fix
            // The calculated pages

            PageReferences.Add(new(20, NextPageText)); // TODO: Fix
            PageReferences.Add(new(20, LastPageText));
        }

        public IEnumerator<PageRef> GetEnumerator()
        {
            return PageReferences.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return PageReferences.GetEnumerator();
        }
    }
}