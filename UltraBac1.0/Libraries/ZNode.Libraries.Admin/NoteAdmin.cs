using System;
using System.Collections.Generic;
using System.Text;
using ZNode.Libraries.DataAccess.Entities;
using ZNode.Libraries.DataAccess.Service;
using ZNode.Libraries.Framework.Business;

namespace ZNode.Libraries.Admin
{
    /// <summary>
    /// Provides methods to manage customer notes
    /// </summary>
    public class NoteAdmin:ZNodeBusinessBase 
    {

        /// <summary>
        /// Returns Cusomer Note for Account ID
        /// </summary>
        /// <param name="AccountID"></param>
        /// <returns></returns>
        public TList<ZNode.Libraries.DataAccess.Entities.Note> GetByAccountID(int AccountID)
        {
            ZNode.Libraries.DataAccess.Service.NoteService _NoteService = new ZNode.Libraries.DataAccess.Service.NoteService();

            TList<ZNode.Libraries.DataAccess.Entities.Note> _CustomerNotesList = _NoteService.GetByAccountID(AccountID);

            return _CustomerNotesList;

        }

        /// <summary>
        /// Returns Cusomer Note for Case ID
        /// </summary>
        /// <param name="AccountID"></param>
        /// <returns></returns>
        public TList<ZNode.Libraries.DataAccess.Entities.Note> GetByCaseID(int CaseID)
        {
            ZNode.Libraries.DataAccess.Service.NoteService _NoteService = new ZNode.Libraries.DataAccess.Service.NoteService();

            TList<ZNode.Libraries.DataAccess.Entities.Note> _CustomerNotesList = _NoteService.GetByCaseID(CaseID);

            return _CustomerNotesList;

        }

        /// <summary>
        /// Add New Customer Note
        /// </summary>
        /// <param name="_Note"></param>
        /// <returns></returns>
        public bool Insert(Note _Note)
        {
            ZNode.Libraries.DataAccess.Service.NoteService _NoteService = new ZNode.Libraries.DataAccess.Service.NoteService();

            bool Status = _NoteService.Insert(_Note);

            return Status;

        }
    }
}
