using LibraryManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalDiaryManagementSystem_dll
{
    public class Diary
    {   //person name eklenmeli ve belki person ıd ayrıca convertion utilyde düzenlenecek
        #region Public Constants
        public const int ID_LENGTH = 14;

        public const int DATE_MAX_LENGTH = 8;        

        public const int BEGIN_TIME_MAX_LENGTH = 5;
        public const int FINISH_TIME_MAX_LENGTH = 5;

        public const int NOTE_MAX_LENGTH = 300;

        public const int PLACE_MAX_LENGTH = 30;
        
        public const int DIARY_DATA_BLOCK_SIZE = ID_LENGTH +
                                                DATE_MAX_LENGTH +
                                                NOTE_MAX_LENGTH +
                                                BEGIN_TIME_MAX_LENGTH +
                                                FINISH_TIME_MAX_LENGTH +
                                                PLACE_MAX_LENGTH;
        #endregion

        #region Private Fields
        private int _id;
        private DateTime _date;        
        private TimeSpan _begin;
        private TimeSpan _finish;
        private string _note;
        private string _place;
        #endregion

        #region Public Properties
        public int Id { get { return _id; } set { _id = value; } }
        public DateTime Date { get { return _date; } set { _date = value; } }        
        public TimeSpan Begin { get { return _begin; } set { _begin = value; } }
        public TimeSpan Finish { get { return _finish; } set { _finish = value; } }
        public string Place { get { return _place; } set { _place = value; } }
        public string Note { get { return _note; } set { _note = value; } }

        #endregion

        //#region Constructors
        //public Diary() {
        //    _authors = new List<string>();
        //    _categories = new List<string>();
        //}
        //#endregion

        #region Utility Methods
        public static byte[] DiaryToByteArrayBlock(Diary diary) {
            int index = 0;

            byte[] dataBuffer = new byte[DIARY_DATA_BLOCK_SIZE];

            #region copy diary id
            byte[] idBytes = ConversionUtility.IntegerToByteArray(diary.Id);
            Array.Copy(idBytes, 0, dataBuffer, index, idBytes.Length);
            index += Diary.ID_LENGTH;
            #endregion

            #region copy diary date
            byte[] dateBytes = ConversionUtility.DateTimeToByteArray(diary.Date);
            Array.Copy(dateBytes, 0, dataBuffer, index, dateBytes.Length);
            index += Diary.DATE_MAX_LENGTH;
            #endregion            

            #region copy diary begin
            byte[] beginBytes = ConversionUtility.TimeSpanToByteArray(diary.Begin);                                                                            
            Array.Copy(beginBytes, 0, dataBuffer, index, beginBytes.Length);
            index += beginBytes.Length;
            #endregion

            #region copy diary finish
            byte[] finishBytes = ConversionUtility.TimeSpanListToByteArray(diary.Finish);                                                                          
            Array.Copy(finishBytes, 0, dataBuffer, index, finishBytes.Length);
            index += finishBytes.Length; 
            #endregion

            #region copy diary note
            byte[] noteBytes = ConversionUtility.StringToByteArray(diary.Note);
            Array.Copy(noteBytes, 0, dataBuffer, index, noteBytes.Length);
            index += Diary.NOTE_MAX_LENGTH;
            #endregion

            #region copy diary place
            byte[] placeBytes = ConversionUtility.StringToByteArray(diary.Place);
            Array.Copy(placeBytes, 0, dataBuffer, index, placeBytes.Length);
            index += Diary.PLACE_MAX_LENGTH;
            #endregion

            if (index != dataBuffer.Length)
            {
                throw new ArgumentException("Index and DataBuffer Size Not Matched");
            }

            return dataBuffer;
        }

        public static Diary ByteArrayBlockToBook(byte[] byteArray) {

            Diary diary = new Diary();

            if (byteArray.Length != DIARY_DATA_BLOCK_SIZE)
            {
                throw new ArgumentException("Byte Array Size Not Match with Constant Data Block Size");
            }

            int index = 0;

            //byte[] dataBuffer = new byte[BOOK_DATA_BLOCK_SIZE];

            #region copy diary id
            byte[] idBytes = new byte[Diary.ID_LENGTH];
            Array.Copy(byteArray, index, idBytes, 0, idBytes.Length);
            diary.Id = ConversionUtility.ByteArrayToInteger(idBytes);

            index += Diary.ID_LENGTH;
            #endregion

            #region copy diary date
            byte[] dateBytes = new byte[Diary.DATE_MAX_LENGTH];
            Array.Copy(byteArray, index, dateBytes, 0, dateBytes.Length);
            diary.Date = ConversionUtility.ByteArrayToDateTime(dateBytes);

            index += Diary.DATE_MAX_LENGTH;
            #endregion
            
            #region copy diary begin
            byte[] beginBytes = new byte[Diary.BEGIN_TIME_MAX_LENGTH];
            Array.Copy(byteArray, index, beginBytes, 0, beginBytes.Length);
            diary.Begin = ConversionUtility.ByteArrayToTimeSpan(beginBytes);

            index += Diary.BEGIN_TIME_MAX_LENGTH;
            #endregion

            #region copy diary finish
            byte[] finishBytes = new byte[Diary.FINISH_TIME_MAX_LENGTH];
            Array.Copy(byteArray, index, finishBytes, 0, finishBytes.Length);
            diary.Finish = ConversionUtility.ByteArrayToTimeSpan(finishBytes);

            index += Diary.FINISH_TIME_MAX_LENGTH;
            #endregion

            #region copy diary note
            byte[] noteBytes = new byte[Diary.NOTE_MAX_LENGTH];
            Array.Copy(byteArray, index, noteBytes, 0, noteBytes.Length);
            diary.Note = ConversionUtility.ByteArrayToString(noteBytes);

            index += Diary.NOTE_MAX_LENGTH;
            #endregion

            #region copy diary place
            byte[] placeBytes = new byte[Diary.PLACE_MAX_LENGTH];
            Array.Copy(byteArray, index, placeBytes, 0, placeBytes.Length);
            diary.Place = ConversionUtility.ByteArrayToString(placeBytes);

            index += Diary.PLACE_MAX_LENGTH;
            #endregion




            if (index != byteArray.Length)
            {
                throw new ArgumentException("Index and DataBuffer Size Not Matched");
            }

            if (diary.Id == 0)
            {
                return null;
            }
            else
            {
                return diary;
            }

        }
    }
}
