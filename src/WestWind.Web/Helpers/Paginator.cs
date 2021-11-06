using System;
using System.Collections;
using System.Collections.Generic;

namespace WebApp.Helpers
{
    public record PageState(int CurrentPage, int PageSize);
    public record PageRef(int Page, string Text);

    public class Paginator : IEnumerable<PageRef>
    {
        #region Public Properties/Fields
        public readonly int TotalItemCount;
        public readonly PageState CurrentState;
        public readonly PageRef CurrentPage;
        public readonly int MaxPageLinks;
        public readonly int FixedPagesBefore;
        public readonly int FixedPagesAfter;
        private List<PageRef> PageReferences;
        public string FirstPageText = "<First>";
        public string LastPageText = "<Last>";
        public string NextPageText = "<Next>";
        public string PreviousPageText = "<Prev>";
        #endregion

        #region Constructor
        public Paginator(int totalItemCount, PageState currentState, int maxPageLinks)
        {
            // 1) Set key properties
            TotalItemCount = totalItemCount;
            CurrentState = currentState;
            CurrentPage = new(currentState.CurrentPage, currentState.CurrentPage.ToString());
            MaxPageLinks = maxPageLinks;
            FixedPagesBefore = MaxPageLinks % 2 == 0 ? (MaxPageLinks / 2) - 1 : MaxPageLinks / 2;
            FixedPagesAfter = MaxPageLinks / 2;

            // 2) Generate the list of page references
            PageReferences = new List<PageRef>();
            PageReferences.Add(new(FirstPage, FirstPageText));
            PageReferences.Add(new(PreviousPage, PreviousPageText));
            // The calculated pages
            for (int pageNumber = FirstPageNumber; pageNumber <= LastPageNumber; pageNumber++)
                PageReferences.Add(new(pageNumber, pageNumber.ToString()));

            PageReferences.Add(new(NextPage, NextPageText));
            PageReferences.Add(new(LastPage, LastPageText));
        }
        #endregion

        #region Methods implementing IEnumerator<PageRef>
        public IEnumerator<PageRef> GetEnumerator()
        {
            return PageReferences.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return PageReferences.GetEnumerator();
        }
        #endregion

        #region Properties with calculated Getters
        ///<summary>PageCount is the total number of pages for the TotalResults</summary>
        public int PageCount { get { return (int)Math.Ceiling((decimal)TotalItemCount / (decimal)CurrentState.PageSize); } }

        ///<summary>NextPage is the human-friendly page number for the next available page</summary>
        public int FirstPage { get { return 1; } }
        ///<summary>PreviousPage is the human-friendly page number for the next available page</summary>
        public int LastPage { get { return PageCount; } }

        ///<summary>NextPage is the human-friendly page number for the next available page</summary>
        public int NextPage { get { return CurrentState.CurrentPage < LastPage ? CurrentState.CurrentPage + 1 : LastPage; } }
        ///<summary>PreviousPage is the human-friendly page number for the next available page</summary>
        public int PreviousPage { get { return CurrentState.CurrentPage > FirstPage ? CurrentState.CurrentPage - 1 : FirstPage; } }


        ///<summary>FirstPageNumber is the first page number in the set of Page Links</summary>
        public int FirstPageNumber
        {
            get
            {
                if (LastPage <= MaxPageLinks)
                    return FirstPage;
                else if (CurrentState.CurrentPage <= FixedPagesBefore)
                    return FirstPage;
                else if (CurrentState.CurrentPage + FixedPagesAfter >= LastPage)
                    return (LastPage - MaxPageLinks + 1);
                else
                    return CurrentState.CurrentPage - FixedPagesBefore;
            }
        }
        ///<summary>LastPageNumber is the last page number in the set of Page Links</summary>
        public int LastPageNumber
        {
            get
            {
                if (LastPage <= MaxPageLinks)
                    return LastPage;
                else if (CurrentState.CurrentPage <= FixedPagesBefore)
                    return MaxPageLinks;
                else if (CurrentState.CurrentPage + FixedPagesAfter >= LastPage)
                    return LastPage;
                else
                    return CurrentState.CurrentPage + FixedPagesAfter;

                //if (LastPage - CurrentState.CurrentPage < MaxPageLinks)
                //    return LastPage;
                //else
                //    return CurrentState.CurrentPage + (MaxPageLinks - 1);
            }
        }
        #endregion
    }
}