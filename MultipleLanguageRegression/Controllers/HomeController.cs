using System;
using System.Web.Mvc;
using System.Diagnostics;
using MultipleLanguageRegression.Models;
using MultipleLanguageRegression.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace MultipleLanguageRegression.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            var vm = new HomeViewModel(Flag.FlagValue);
            return View(vm);
        }

        public class RegressionResponse
        {
            public string ReportLocation { get; set; }
        }

        [HttpPost]
        public JsonResult ExecuteRegressionBat(RegressionRequest request)
        {
            Flag.FlagValue = true;
            List<string> languageCatagory = new List<string>();
            //change config
            languageCatagory = LanguageSelected(request.LanguageList);
            ChangeCatagory(languageCatagory);

            var reportPath = ExecuteRegressionConfig(request.ExpId);

            var proc = new Process();
            proc.StartInfo.FileName = "###FILEPATH###";
            proc.StartInfo.WorkingDirectory = "###FILEPATH###";
            proc.StartInfo.CreateNoWindow = true;
            proc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            proc.Start();
            proc.WaitForExit();
            proc.Close();
            //Thread.Sleep(5000);
            Flag.FlagValue = false;

            DateTime lastModified = System.IO.File.GetLastWriteTime("###FILEPATH###");
            string reportTime = lastModified.ToString("HHmmss");
            var fullPath = reportPath + reportTime + "/Report.html";
            
            return Json(new RegressionResponse() { ReportLocation = fullPath }, JsonRequestBehavior.AllowGet);
        }

        public string ExecuteRegressionConfig(string expid)
        {
            string website_url = "###URL###";
            string selenium_hub_url = "";
            //string selenium_hub_url = "###URL###";
            string report_directory = "###FILEPATH###";
            string force_experiment = "explist=" + expid;

            Process.Start("Powershell.exe", String.Format("###FILEPATH### '{0}' '{1}' '{2}' '{3}'", website_url, selenium_hub_url, report_directory, force_experiment));

            return "###URL###" + "_" + DateTime.Today.ToString("yyyMMdd") + "_";
        }

        public void ChangeCatagory(List<string> cat)
        {
            string catForRun = "";

            if (cat.All(x => string.IsNullOrWhiteSpace(x)) || cat.Count == 49)
            {
                catForRun = "cat==MultipleLanguage";
            }
            else
            {
                for (int i = 0; i < cat.Count; i++)
                {
                    if (cat.Count == 1)
                    {
                        catForRun = "cat==" + cat[0];
                    }
                    else
                    {
                        catForRun = catForRun + "cat==" + cat[i] + " or ";
                    }
                }
                if (cat.Count > 1)
                {
                    catForRun = catForRun.Substring(0, catForRun.Length - 3);
                }
            }

            Process.Start("Powershell.exe", String.Format("###FILEPATH### '{0}'", catForRun));
        }

        [HttpGet]
        public bool CheckFlag()
        {
            return Flag.FlagValue;
        }

        [HttpGet]
        public List<string> LanguageSelected(List<int> languageList)
        {
            List<string> languageselectedforcat = new List<string>();

            if (languageList.Count == 0 || languageList.Count == 49)
            {
                languageselectedforcat.Add("MultipleLanguage");
            }
            else
            {
                for (int i = 0; i < languageList.Count; i++)
                {
                    switch (languageList[i])
                    {
                        case 1:
                            languageselectedforcat.Add("MultipleLanguageUSA");
                            break;
                        case 2:
                            languageselectedforcat.Add("MultipleLanguageFrance");
                            break;
                        case 3:
                            languageselectedforcat.Add("MultipleLanguageGermany");
                            break;
                        case 4:
                            languageselectedforcat.Add("MultipleLanguageItaly");
                            break;
                        case 5:
                            languageselectedforcat.Add("MultipleLanguageCastilian");
                            break;
                        case 6:
                            languageselectedforcat.Add("MultipleLanguageJapan");
                            break;
                        case 7:
                            languageselectedforcat.Add("MultipleLanguageHongKong");
                            break;
                        case 8:
                            languageselectedforcat.Add("MultipleLanguageChinese");
                            break;
                        case 9:
                            languageselectedforcat.Add("MultipleLanguageKorea");
                            break;
                        case 10:
                            languageselectedforcat.Add("MultipleLanguageGreece");
                            break;
                        case 11:
                            languageselectedforcat.Add("MultipleLanguagePortugal");
                            break;
                        case 12:
                            languageselectedforcat.Add("MultipleLanguageNetherlands");
                            break;
                        case 13:
                            languageselectedforcat.Add("MultipleLanguageCanada");
                            break;
                        case 14:
                            languageselectedforcat.Add("MultipleLanguageIndia");
                            break;
                        case 15:
                            languageselectedforcat.Add("MultipleLanguageUK");
                            break;
                        case 16:
                            languageselectedforcat.Add("MultipleLanguageSouthAfrica");
                            break;
                        case 17:
                            languageselectedforcat.Add("MultipleLanguageAustralia");
                            break;
                        case 18:
                            languageselectedforcat.Add("MultipleLanguageSingapore");
                            break;
                        case 19:
                            languageselectedforcat.Add("MultipleLanguageTaiwan");
                            break;
                        case 20:
                            languageselectedforcat.Add("MultipleLanguageNewZealand");
                            break;
                        case 21:
                            languageselectedforcat.Add("MultipleLanguageThailand");
                            break;
                        case 22:
                            languageselectedforcat.Add("MultipleLanguageMalaysia");
                            break;
                        case 23:
                            languageselectedforcat.Add("MultipleLanguageVietNam");
                            break;
                        case 24:
                            languageselectedforcat.Add("MultipleLanguageSweden");
                            break;
                        case 25:
                            languageselectedforcat.Add("MultipleLanguageIndonesia");
                            break;
                        case 26:
                            languageselectedforcat.Add("MultipleLanguagePoland");
                            break;
                        case 27:
                            languageselectedforcat.Add("MultipleLanguageNorway");
                            break;
                        case 28:
                            languageselectedforcat.Add("MultipleLanguageDenmark");
                            break;
                        case 29:
                            languageselectedforcat.Add("MultipleLanguageFinland");
                            break;
                        case 30:
                            languageselectedforcat.Add("MultipleLanguageCzech");
                            break;
                        case 31:
                            languageselectedforcat.Add("MultipleLanguageTurkey");
                            break;
                        case 32:
                            languageselectedforcat.Add("MultipleLanguageSpain");
                            break;
                        case 33:
                            languageselectedforcat.Add("MultipleLanguageHungary");
                            break;
                        case 34:
                            languageselectedforcat.Add("MultipleLanguageIndia");
                            break;
                        case 35:
                            languageselectedforcat.Add("MultipleLanguageBulgaria");
                            break;
                        case 36:
                            languageselectedforcat.Add("MultipleLanguageRomania");
                            break;
                        case 37:
                            languageselectedforcat.Add("MultipleLanguageSlovenia");
                            break;
                        case 38:
                            languageselectedforcat.Add("MultipleLanguageIsrael");
                            break;
                        case 39:
                            languageselectedforcat.Add("MultipleLanguageUAE");
                            break;
                        case 40:
                            languageselectedforcat.Add("MultipleLanguageBelgium");
                            break;
                        case 41:
                            languageselectedforcat.Add("MultipleLanguageIreland");
                            break;
                        case 42:
                            languageselectedforcat.Add("MultipleLanguageBrazil");
                            break;
                        case 43:
                            languageselectedforcat.Add("MultipleLanguageArgentina");
                            break;
                        case 44:
                            languageselectedforcat.Add("MultipleLanguageMexico");
                            break;
                        case 45:
                            languageselectedforcat.Add("MultipleLanguageLithuania");
                            break;
                        case 46:
                            languageselectedforcat.Add("MultipleLanguageLatvia");
                            break;
                        case 47:
                            languageselectedforcat.Add("MultipleLanguageCroatia");
                            break;
                        case 48:
                            languageselectedforcat.Add("MultipleLanguageEstonia");
                            break;
                        case 49:
                            languageselectedforcat.Add("MultipleLanguageUkraine");
                            break;
                        case 50:
                            languageselectedforcat.Add("MultipleLanguageRussia");
                            break;
                    }
                }
            }
            return languageselectedforcat;
        }
    }
}