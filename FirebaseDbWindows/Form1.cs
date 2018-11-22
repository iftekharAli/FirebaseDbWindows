using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using System;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FirebaseDbWindows
{
    public partial class Form1 : Form
    {
        private static int _sec = 0;
        private string _qno = "";
        private string _qid = "";
        private int _interuption = 0;
        private int _fristquestionsleep = 0;
        private IFirebaseConfig Config = new FirebaseConfig
        {
            AuthSecret = "YqNUbjNyaMTqpQyNq2iuFeUKK8hS83LChHCHlcP9",
            BasePath = "https://playnwin-ffa32.firebaseio.com/"
        };

        private IFirebaseClient Client;
        public Form1()
        {
            InitializeComponent();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            TimeToSleep();
            Client = new FireSharp.FirebaseClient(Config);
            lblSec.Text = _sec.ToString();
            lblInter.Text = _interuption.ToString();
            lblqno.Text = _qno.ToString();
            lbl1q.Text = _fristquestionsleep.ToString();
            if (_sec == -1)
            {
                _sec = 15;
            }
            if (_interuption == 0 && _fristquestionsleep == 0)
            {
                switch (_sec)
                {
                    case 1:
                        GetQuestionList();
                        break;
                    case 15:
                        UpdateListWithRightWrong();
                        break;
                    case 18:
                        _sec = 0;
                        break;
                        //default:
                        //{
                        //    UpdateListWithRightWrong();
                        //    break;
                        //}
                }

            }

            if (_fristquestionsleep > 0)
            {

                if (_qno == "-5" && _fristquestionsleep>0)
                {
                    //questionData.Others = "LevelHome";
                    _fristquestionsleep++;
                    if (_fristquestionsleep >= 15)
                    {
                        RetriveData("");
                        _sec = -15; _interuption = 0;
                        _fristquestionsleep = 0;
                        //_qno = "-5";
                    }
                }


            }

            if (_qno == "20" || _qno == "30")
            {
                if (_interuption == 18)
                {
                    string levelInstructionTex = string.Empty;
                    levelInstructionTex = _qno == "20" ? "Level2" : "Level3";
                    RetriveData(levelInstructionTex);
                }
                _interuption++;
            }
            if (_sec == 0 && _qno == "40")
            {
               
                //new CDA().ExecuteNonQuery("exec sp_QuestionCountToZero", "WAPDB");
                RetriveData("END");
                new CDA().ExecuteNonQuery("EXEC sp_QpDailyResult", "WAPDB");
                _interuption++;
               
            }

            if (_sec >= 40)
            {
                //   _sec = 0; _interuption = 0;
                // RetriveData("LevelHome");
            }

            if (_sec >= 40)
            {
                _sec = 0; _interuption = 0; _fristquestionsleep = 0;
                 _qno = "-1";

            }
            _sec++;
            //if (_sec == 1 && _sec == 15)
            //{
            //    _sec++;
            //}
        }

        private void TimeToSleep()
        {
            string theDate = string.Empty;
            var hour = DateTime.Now.Hour;
            var min = DateTime.Now.Minute;
            var time = Convert.ToInt16(new CDA().getSingleValue("select hour from tbl_DailyQuizStartTime order by id desc", "WAPDB"));// _context.tbl_DailyQuizStartTime.OrderByDescending(x => x.Id).FirstOrDefault();
            var dbhour = Convert.ToInt16(time);
            if (hour < dbhour)
            {
                theDate = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, dbhour, 0, 0).ToString("yyyy-MM-dd HH:mm:ss");
            }
            else
            {
                theDate = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, dbhour, 0, 0).AddDays(1).ToString("yyyy-MM-dd HH:mm:ss");
            }
            var todaysdate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second).ToString("yyyy-MM-dd HH:mm:ss");
            var diff = (Convert.ToDateTime(theDate) - Convert.ToDateTime(todaysdate)).TotalSeconds;
        }

        private async Task GetQuestionList()
        {
            DataSet ds = new CDA().GetDataSet("exec sp_getDailyQuestionList 1", "WAPDB");
            if (ds != null)
            {
                var quesList = EnumerableRowCollection(ds);
                var questionData = quesList.FirstOrDefault();
                //_qno = Convert.ToInt16(questionData.QuestionNo).ToString();
                if (Convert.ToInt16(questionData.QuestionNo) > 1)
                {
                    _qno = Convert.ToInt16(questionData.QuestionNo).ToString();
                }
                else if (Convert.ToInt16(questionData.QuestionNo) == 1)
                {
                    _qno = "1";
                }
                await InsertintoFirebaseDb(questionData);
            }
            else
            {
                RetriveData("BeforeLive");
            }
        }

        private async Task UpdateListWithRightWrong()
        {
            DataSet dsRightWrong = new CDA().GetDataSet("Exec sp_AppDailyResultEach " + _qid, "WAPDB");

            if (dsRightWrong != null)
            {
                string rightanswer = dsRightWrong.Tables[0].Rows[0]["RightAnswer"].ToString();
                string wronganswer = dsRightWrong.Tables[0].Rows[0]["WrongAnswer"].ToString();
                new CDA().ExecuteNonQuery(
                    "Exec sp_UpdateDailyQuestionList '" + _qid + "','" + rightanswer + "','" + wronganswer +
                    "'", "WAPDB");
                DataSet dsUpdatedList =
                    new CDA().GetDataSet("Exec sp_getDailyQuestionListUpdate '" + _qid + "'", "WAPDB");
                if (dsUpdatedList != null)
                {
                    var quesList = EnumerableRowCollection(dsUpdatedList);
                    var questionData = quesList.FirstOrDefault();
                    await InsertintoFirebaseDb(questionData);
                }
            }
            else
            {
                string rightanswer = "0";
                string wronganswer = "0";
                new CDA().ExecuteNonQuery(
                    "Exec sp_UpdateDailyQuestionList '" + _qid + "','" + rightanswer + "','" + wronganswer +
                    "'", "WAPDB");
                DataSet dsUpdatedList =
                    new CDA().GetDataSet("Exec sp_getDailyQuestionListUpdate '" + _qid + "'", "WAPDB");
                if (dsUpdatedList != null)
                {
                    var quesList = EnumerableRowCollection(dsUpdatedList);
                    var questionData = quesList.FirstOrDefault();
                    await InsertintoFirebaseDb(questionData);
                }
            }
        }

        private async Task InsertintoFirebaseDb(QuestionList questionData)
        {
            if (questionData != null)
            {
                _qid = questionData.QuestionId;
                if (_qno != "-5")
                {
                    _qno = questionData.QuestionNo;

                }
                if (_qno == "1")
                {
                    questionData.Others = "LevelHome";
                    _fristquestionsleep++;
                    _qno = "-5";

                }
                if (_qno == "-1")
                {
                    questionData.Others = "BeforeLive";
                }
                else if (_qno != "-5")
                {
                    _qno = questionData.QuestionNo;
                }

                SetResponse response = await Client.SetTaskAsync("DailyQuiz/QuestionSet", questionData);
                QuestionList res = response.ResultAs<QuestionList>();
                _sec++;
            }
        }

        private async Task RetriveData(string type)
        {
            FirebaseResponse response = await Client.GetTaskAsync("DailyQuiz/QuestionSet");
            QuestionList res = response.ResultAs<QuestionList>();
            res.Others = type;
            await InsertintoFirebaseDb(res);
        }

        private static EnumerableRowCollection<QuestionList> EnumerableRowCollection(DataSet ds)
        {
            EnumerableRowCollection<QuestionList> quesList = ds.Tables[0]
                .AsEnumerable()
                .Select(row => new QuestionList
                {
                    QuestionId = row.Field<string>("QuestionId"),
                    Level = row.Field<string>("Level"),
                    QuestionImage = row.Field<string>("QuestionImage"),
                    Question = row.Field<string>("Question"),
                    Option1 = row.Field<string>("Option1"),
                    Option2 = row.Field<string>("Option2"),
                    Option3 = row.Field<string>("Option3"),
                    Option4 = "",
                    Answer = row.Field<string>("Answer"),
                    QuestionNo = row.Field<string>("QuestionNo"),
                    RightAnswer = row.Field<string>("RightAnswer"),
                    WrongAnswer = row.Field<string>("WrongAnswer"),
                    PrizeSummary = row.Field<string>("PrizeSummary"),
                    PrizeDescription = row.Field<string>("PrizeDescription"),
                    Others = row.Field<string>("Others"),

                });
            return quesList;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Client = new FireSharp.FirebaseClient(Config);
            lblSec.Text = _sec.ToString();
            // RetriveData();
            lblInter.Text = _interuption.ToString();
            lblqno.Text = _qno.ToString();
            lbl1q.Text = _fristquestionsleep.ToString();
            if (_interuption == 0 && _fristquestionsleep == 0)
            {
                switch (_sec)
                {
                    case 1:
                        GetQuestionList();
                        break;
                    case 15:
                        UpdateListWithRightWrong();
                        break;
                    case 18:
                        _sec = 0;
                        break;
                        //default:
                        //{
                        //    UpdateListWithRightWrong();
                        //    break;
                        //}
                }

            }

            if (_fristquestionsleep > 0)
            {

                if (_qno == "1")
                {
                    //questionData.Others = "LevelHome";
                    _fristquestionsleep++;
                    if (_fristquestionsleep >= 2)
                    {
                        RetriveData("");
                        _sec = 0; _interuption = 0;
                        _fristquestionsleep = 0;
                    }
                }


            }

            if (_qno == "20" || _qno == "30")
            {
                if (_interuption == 18)
                {
                    string levelInstructionTex = string.Empty;
                    levelInstructionTex = _qno == "20" ? "Level2" : "Level3";
                    RetriveData(levelInstructionTex);
                }
                _interuption++;
            }

            //if (_interuption >= 40)
            //{
            //    _interuption = 0;
            //    _sec = 0;
            //}

            if (_sec == 0 && _qno == "40")
            {
                _qno = "-1";
                //new CDA().ExecuteNonQuery("exec sp_QuestionCountToZero", "WAPDB");
                RetriveData("END");
                new CDA().ExecuteNonQuery("EXEC sp_QpDailyResult", "WAPDB");
                _interuption++;
            }

            if (_sec >= 40)
            {
                //   _sec = 0; _interuption = 0;
                // RetriveData("LevelHome");
            }

            if (_sec >= 120)
            {
                _sec = 0; _interuption = 0;

            }
            _sec++;
            //if (_sec == 1 && _sec == 15)
            //{
            //    _sec++;
            //}
        }
    }
}
