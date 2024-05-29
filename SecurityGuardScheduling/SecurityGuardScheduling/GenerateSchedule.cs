using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Data;
using dbConnection;
using System.Windows.Forms;

namespace SecurityGuardScheduling
{
    class GenerateSchedule
    {


        const string offDutyShiftkey = "OFF";
        const string newGaurdkey = "NEW";

        public bool erraseExisting = false;

        int intSheduleSingleCycle = 3;
        int intOFFCycleDutiesToConsider = 2;
        int cycleMidWay = 0;

        DateTime tm_ScheduleStartDate;
        DateTime tm_ScheduleEndDate;

        DateTime tm_CurrentCycleBeggingDate;
        DateTime tm_CurrentCycleEndingDate;
        DateTime tm_CurrentProcessingDate;

        Random rnd = new Random();

        DataTable searchQuery = new DataTable();

        DataTable dtAllActivePosts = new DataTable();
        DataTable dtAllActiveShifts = new DataTable();
        DataTable dtAllActiveGaurds = new DataTable();

        DataTable dtDailyGardAvailbitlySheet = new DataTable(); // Each Duty's total daily available Gaurd Count.
        DataTable dtDailyDutyAvailbitlySheet = new DataTable(); // Each Gaurd's total daily available Duty Count.
        DataTable dtDailyDutyPossibiltySheet = new DataTable(); //Assignment Possiblity Sheet among duty and Gaurds.

        DataTable dtGardRandomDutyDraw = new DataTable();
        DataTable dtDutyRandomGardDraw = new DataTable();

        DataTable dtExistingDuty = new DataTable();

        DataTable dtOFFDuties = new DataTable();

        DataTable dtNewDuty = new DataTable();

        dataBuilder getDataFromDB = new dataBuilder();


        private void writeT1oFile(string str)
        {
            this.getDataFromDB.writeToFile(str, "log.csv");
        }

        private void wr1_2(string str)
        {
            this.getDataFromDB.writeToFile(str, "log2.csv");
        }

        private void wr_2(string str)
        {
            this.getDataFromDB.writeToFile(str, "log1.csv");
        }

        private int countActiveGaurdForDate(DateTime dutyDate)
        {
            DataTable activeGaurdList = 
                this.getDataFromDB.getGS_GAURDInfo(null, "", "", "", "", "", true, false, "AND");

            DataTable gaurdDateExclusion = new DataTable();
            DataTable dayExclusion;


            gaurdDateExclusion =
                this.getDataFromDB.getGS_EXCLUSIONInfo(null, "", "", triaStateBool.yes, 
                    triaStateBool.no, triaStateBool.no, true, false, "AND");

            foreach (DataRow dr in gaurdDateExclusion.Rows)
            {
                if (dr["ISDAY_EXCLUSION"].ToString() == "Y" &&
                    dr["ISDATE_EXCLUSION"].ToString() == "N" )
                {
                    dayExclusion =
                            this.getDataFromDB.getGS_DAY_EXCLUSIONInfo(null, "",
                                dr["GS_EXCLUSION_ID"].ToString(),
                                this.getCorrespondingDayOfWeek(dutyDate.ToString("ddd")),
                                true, false, "AND");
                    if (!this.getDataFromDB.checkIfTableContainesData(dayExclusion))
                        dr["ISACTIVE"] = "N";
                }
                else if (dr["ISDAY_EXCLUSION"].ToString() == "N" &&
                    dr["ISDATE_EXCLUSION"].ToString() == "Y")
                {
                    if (dr["ISRANGE_EXCLUSION"].ToString() == "Y")
                    {
                        if (DateTime.Parse(dr["EXCLUSION_DATE_BEGIN"].ToString()).CompareTo(dutyDate.Date) > 0 ||
                            DateTime.Parse(dr["EXCULSION_DATE_END"].ToString()).CompareTo(dutyDate.Date) < 0)
                        {
                            dr["ISACTIVE"] = "N";
                        }
                    }
                    else if(DateTime.Parse(dr["EXCLUSION_DATE_BEGIN"].ToString()).CompareTo(dutyDate.Date) != 0)
                    {
                        dr["ISACTIVE"] = "N";
                    }
                }
                else if (dr["ISDAY_EXCLUSION"].ToString() == "Y" &&
                    dr["ISDATE_EXCLUSION"].ToString() == "Y")
                {
                    if (dr["ISDAY_DATE_COMBINATION"].ToString() == "Y")
                    {
                        if (dr["ISRANGE_EXCLUSION"].ToString() == "Y")
                        {
                            if (DateTime.Parse(dr["EXCLUSION_DATE_BEGIN"].ToString()).CompareTo(dutyDate.Date) > 0 ||
                                DateTime.Parse(dr["EXCULSION_DATE_END"].ToString()).CompareTo(dutyDate.Date) < 0)
                            {
                                dr["ISACTIVE"] = "N";
                            }
                            else
                            {
                                dayExclusion =
                                    this.getDataFromDB.getGS_DAY_EXCLUSIONInfo(null, "",
                                                dr["GS_EXCLUSION_ID"].ToString(),
                                                this.getCorrespondingDayOfWeek(dutyDate.ToString("ddd")),
                                                true, false, "AND");

                                if (!this.getDataFromDB.checkIfTableContainesData(dayExclusion))
                                    dr["ISACTIVE"] = "N";
                            }
                        }
                        else
                        {
                            if (DateTime.Parse(dr["EXCLUSION_DATE_BEGIN"].ToString()).CompareTo(dutyDate.Date) != 0)
                            {
                                dr["ISACTIVE"] = "N";
                            }
                            else
                            {
                                dayExclusion =
                                    this.getDataFromDB.getGS_DAY_EXCLUSIONInfo(null, "",
                                                dr["GS_EXCLUSION_ID"].ToString(),
                                                this.getCorrespondingDayOfWeek(dutyDate.ToString("ddd")),
                                                true, false, "AND");

                                if (!this.getDataFromDB.checkIfTableContainesData(dayExclusion))
                                    dr["ISACTIVE"] = "N";
                            }
                        }
                    }
                    else
                    {
                        dayExclusion =
                                this.getDataFromDB.getGS_DAY_EXCLUSIONInfo(null, "",
                                            dr["GS_EXCLUSION_ID"].ToString(),
                                            this.getCorrespondingDayOfWeek(dutyDate.ToString("ddd")),
                                            true, false, "AND");
                        if (dr["ISRANGE_EXCLUSION"].ToString() == "Y")
                        {
                            if ((DateTime.Parse(dr["EXCLUSION_DATE_BEGIN"].ToString()).CompareTo(dutyDate.Date) > 0 ||
                                DateTime.Parse(dr["EXCULSION_DATE_END"].ToString()).CompareTo(dutyDate.Date) < 0) &&
                                !this.getDataFromDB.checkIfTableContainesData(dayExclusion))
                            {
                                dr["ISACTIVE"] = "N";
                            }
                        }
                        else if(DateTime.Parse(dr["EXCLUSION_DATE_BEGIN"].ToString()).CompareTo(dutyDate.Date) != 0 &&
                            !this.getDataFromDB.checkIfTableContainesData(dayExclusion))
                        {
                            dr["ISACTIVE"] = "N";
                        }
                    }
                }
            }

            for (int rowCounter = gaurdDateExclusion.Rows.Count - 1; rowCounter >= 0; rowCounter--)
            {
                if (gaurdDateExclusion.Rows[rowCounter]["ISACTIVE"].ToString() == "")
                {
                    gaurdDateExclusion.Rows.RemoveAt(rowCounter);
                }
            }

            foreach (DataRow dr in activeGaurdList.Rows)
            {
                foreach (DataRow dr2 in gaurdDateExclusion.Rows)
                {
                    dayExclusion =
                        this.getDataFromDB.getGS_GAURD_EXCLUSIONInfo(null, "",
                            dr2["GS_EXCLUSION_ID"].ToString(), dr["GS_GAURD_ID"].ToString(),
                            true, false, "AND");

                    if (this.getDataFromDB.checkIfTableContainesData(dayExclusion))
                    {
                        dr["ISACTIVE"] = "N";
                        break;
                    }
                }
            }

            for (int rowCounter = activeGaurdList.Rows.Count - 1; rowCounter >= 0; rowCounter--)
            {
                if (activeGaurdList.Rows[rowCounter]["ISACTIVE"].ToString() == "")
                {
                    activeGaurdList.Rows.RemoveAt(rowCounter);
                }
            }

            return activeGaurdList.Rows.Count;
        }

        private void calculateSingleCycleDays()
        {
            int[] singleCycleDays = new int[]{0,0};            
            //bool recordFound = false;

            DataTable dtDailyPostGaurdCount = new DataTable();
            DataTable dtPostFrequenceyTally = new DataTable();

            dtDailyPostGaurdCount.Columns.Add("Date");
            dtDailyPostGaurdCount.Columns.Add("PostCount");
            dtDailyPostGaurdCount.Columns.Add("GaurdCount");


            //dtPostFrequenceyTally.Columns.Add("PostCount");
            //dtPostFrequenceyTally.Columns.Add("Frequency");

            dtDailyPostGaurdCount.Rows.Add(new object[] { 
                        this.dtNewDuty.Rows[0]["DUTYDATE"], 0, 
                        this.countActiveGaurdForDate(DateTime.Parse(this.dtNewDuty.Rows[0]["DUTYDATE"].ToString()))});
            
            for (int rowCounter = 0; rowCounter <= this.dtNewDuty.Rows.Count - 1; rowCounter++)
            {
                if (this.dtNewDuty.Rows[rowCounter]["DUTYDATE"].ToString() ==
                    dtDailyPostGaurdCount.Rows[dtDailyPostGaurdCount.Rows.Count - 1]["Date"].ToString())
                {
                    dtDailyPostGaurdCount.Rows[dtDailyPostGaurdCount.Rows.Count - 1]["PostCount"] =
                        int.Parse(dtDailyPostGaurdCount.Rows[dtDailyPostGaurdCount.Rows.Count - 1]["PostCount"].ToString()) + 1;
                }
                else
                {
                    dtDailyPostGaurdCount.Rows.Add(new object[] { 
                        this.dtNewDuty.Rows[0]["DUTYDATE"], 1, 
                        this.countActiveGaurdForDate(DateTime.Parse(this.dtNewDuty.Rows[0]["DUTYDATE"].ToString()))});
                }
            
            }

            decimal averagePostCount = 0;
            decimal averageGaurdCount = 0;
            for (int rowCounter = 0; rowCounter <= dtDailyPostGaurdCount.Rows.Count - 1; rowCounter++)
            {
                averagePostCount = averagePostCount +
                    decimal.Parse(dtDailyPostGaurdCount.Rows[rowCounter]["PostCount"].ToString());

                averageGaurdCount = averageGaurdCount +
                    decimal.Parse(dtDailyPostGaurdCount.Rows[rowCounter]["GaurdCount"].ToString());
            }

            averagePostCount = averagePostCount / 
                dtDailyPostGaurdCount.Rows.Count != 0 ?
                    dtDailyPostGaurdCount.Rows.Count : 1;
            averageGaurdCount = averageGaurdCount /
                dtDailyPostGaurdCount.Rows.Count != 0 ?
                    dtDailyPostGaurdCount.Rows.Count : 1;

            if (averageGaurdCount >= averagePostCount)
            {
                this.intSheduleSingleCycle = int.Parse(Math.Round(averageGaurdCount, 0).ToString());
            }
            else
            {
                this.intSheduleSingleCycle = int.Parse(Math.Round(averagePostCount, 0).ToString());
            }

            //dtPostFrequenceyTally.Rows.Add(new object[] { dtDailyPostGaurdCount.Rows[0]["PostCount"], 0 });

            //for (int rowCounter = 0; rowCounter <= dtDailyPostGaurdCount.Rows.Count - 1; rowCounter++)
            //{
            //    recordFound = false;
            //    for (int rowCounter2 = 0; rowCounter2 <= dtPostFrequenceyTally.Rows.Count - 1; rowCounter2++)
            //    {

            //        if (dtPostFrequenceyTally.Rows[rowCounter2]["PostCount"].ToString() ==
            //            dtDailyPostGaurdCount.Rows[rowCounter]["PostCount"].ToString())
            //        {
            //            dtPostFrequenceyTally.Rows[rowCounter2]["Frequency"] =
            //                int.Parse(dtPostFrequenceyTally.Rows[rowCounter2]["Frequency"].ToString()) + 1;
            //            recordFound = true;
            //            break;
            //        }
            //    }

            //    if (recordFound == false)
            //        dtPostFrequenceyTally.Rows.Add(new object[] { this.dtNewDuty.Rows[rowCounter]["PostCount"], 1 });
            //}


            //for (int rowCounter = 0; rowCounter <= dtPostFrequenceyTally.Rows.Count - 1; rowCounter++)
            //{
            //    if (int.Parse(dtPostFrequenceyTally.Rows[rowCounter]["Frequency"].ToString()) > singleCycleDays[1])
            //    {
            //        singleCycleDays[0] = int.Parse(dtPostFrequenceyTally.Rows[rowCounter]["PostCount"].ToString());
            //        singleCycleDays[1] = int.Parse(dtPostFrequenceyTally.Rows[rowCounter]["Frequency"].ToString());
            //    }
            //}


        }

        private int getRandomNumber(int lowerInclusiveNo, int upperExclusiveNo)
        {
            int rndNumber = lowerInclusiveNo;

            Random rnd_2 = new Random();

            int drawTaken = rnd_2.Next(lowerInclusiveNo, upperExclusiveNo);
            do
            {
                rndNumber = rnd.Next(lowerInclusiveNo, upperExclusiveNo);
                drawTaken--;

            } while (drawTaken >= lowerInclusiveNo);
            return rndNumber;
        }

        private daysOfWeek getCorrespondingDayOfWeek(string dOw)
        {
            List<daysOfWeek> lsDaysOfWeek =
                new List<daysOfWeek>((daysOfWeek[])Enum.GetValues(typeof(daysOfWeek)));

            foreach (daysOfWeek day in lsDaysOfWeek)
            {
                if (day.ToString().ToUpper() == dOw.ToUpper())
                    return day;
            }
            return daysOfWeek.A_None;
        }

        private string generateEquivalentSymbol(string symbolInText)
        {
            if (symbolInText == "Equals to")
                return "=";
            if (symbolInText == "Not equals to")
                return "!=";
            if (symbolInText == "Similar to")
                return "like";
            if (symbolInText == "Not similar to")
                return "not like";
            if (symbolInText == "Greater than")
                return ">";
            if (symbolInText == "Greater or equals to")
                return ">=";
            if (symbolInText == "Less than")
                return "<";
            if (symbolInText == "Lesser or equal to")
                return "<=";
            return "";
        }


        private void addMoreCriteria(string field, string criterion, string valueFrom, string valueTo)
        {
            if (field == "" || criterion == "" || valueFrom == "")
                return;
            if (criterion == "In between of")
            {
                this.addMoreCriteria(field, "Greater or equals to", valueFrom, "");
                this.addMoreCriteria(field, "Lesser or equal to", valueTo, "");
            }
            else
            {
                DataRow criteriaValue = this.searchQuery.NewRow();

                criteriaValue["Field"] = field;
                criteriaValue["Criterion"] = this.generateEquivalentSymbol(criterion);
                if (criteriaValue["Criterion"].ToString() == "like")
                    criteriaValue["Value"] = "%" + valueFrom.ToUpper() + "%";
                else
                    criteriaValue["Value"] = valueFrom;
                this.searchQuery.Rows.Add(criteriaValue);
            }

        }

        private void erraseExistingDutyAssignment()
        {
            string deleteQuery = "DELETE FROM GS_DUTY " +
                                 "WHERE DUTYDATE >= #" + this.tm_ScheduleStartDate.ToString("dd-MMM-yyyy") + " 00:00:00# " +
                                 "AND DUTYDATE <= #" + this.tm_ScheduleEndDate.ToString("dd-MMM-yyyy") + " 23:59:59#";

            this.getDataFromDB.executeSqlOnDB(deleteQuery);
        }

        private void fetchExistingDateRangeDutyAssignment(BackgroundWorker _backGrounWorker, int singleDayPrcIncrement)
        {
            this.searchQuery.Clear();

            if (this.searchQuery.Columns.Count == 0)
            {
                this.searchQuery.Columns.Add("Field");
                this.searchQuery.Columns.Add("Criterion");
                this.searchQuery.Columns.Add("Value");
            }

            this.addMoreCriteria("DUTYDATE", "In between of",
                "#" + this.tm_ScheduleStartDate.ToString("dd-MMM-yyyy") + " 00:00:00#",
                "#" + this.tm_ScheduleEndDate.ToString("dd-MMM-yyyy") + " 23:59:59#");

            this.dtNewDuty =
               this.getDataFromDB.getGS_DUTY(searchQuery, "AND", "", DateTime.Now,
                   false, triaStateBool.Ignor, "", "", "",
                   "", false, false, "AND");

            if (!this.getDataFromDB.checkIfTableContainesData(this.dtNewDuty))
                return;

            DataView dtvSortDtNewDuty = this.dtNewDuty.DefaultView;
            dtvSortDtNewDuty.Sort = "DUTYDATE ASC, GS_DUTY_ID ASC";

            this.dtNewDuty = dtvSortDtNewDuty.ToTable();

            DateTime tm_CompareDateToDate_local = this.tm_ScheduleStartDate;
            DateTime tm_CurrentDutyDate_local;

            List<DateTime> missingDutyDate = new List<DateTime>();

            int dutyRowCounter = 0;
            while (dutyRowCounter <= this.dtNewDuty.Rows.Count - 1)
            {
                tm_CurrentDutyDate_local =
                    DateTime.Parse(this.dtNewDuty.Rows[dutyRowCounter]["DUTYDATE"].ToString());
                if (tm_CurrentDutyDate_local.Date.CompareTo(tm_CompareDateToDate_local.Date) == 0)
                {
                    dutyRowCounter++;
                    continue;
                }
                else if (dutyRowCounter != 0)
                {
                    if ((tm_CurrentDutyDate_local.Date - tm_CompareDateToDate_local.Date).TotalDays == 1)
                    {
                        tm_CompareDateToDate_local = tm_CurrentDutyDate_local;
                        dutyRowCounter++;
                        continue;
                    }
                }

                int missingNumberOfDays =
                    int.Parse((tm_CurrentDutyDate_local.Date - tm_CompareDateToDate_local.Date).TotalDays.ToString());

                if (dutyRowCounter == 0)
                {
                    missingDutyDate.Add(tm_CompareDateToDate_local);
                    missingNumberOfDays--;
                }

                while (missingNumberOfDays > 0)
                {
                    tm_CompareDateToDate_local = tm_CompareDateToDate_local.AddDays(1);
                    missingNumberOfDays--;
                    missingDutyDate.Add(tm_CompareDateToDate_local);
                }

                tm_CompareDateToDate_local =
                    tm_CompareDateToDate_local.AddDays(1);
            }

            if (missingDutyDate.Count == 0)
                return;

            this.setUpLookUpTables();

            foreach (DateTime dtm in missingDutyDate)
            {
                this.createNewDutyAssignmentTable(dtm, dtm);
            }

            dtvSortDtNewDuty = this.dtNewDuty.DefaultView;
            dtvSortDtNewDuty.Sort = "DUTYDATE ASC, GS_DUTY_ID ASC";
            this.createAssingment(_backGrounWorker, singleDayPrcIncrement);

        }

        private void saveNewDutyInfo()
        {
            this.getDataFromDB.changeDataBaseTableData(this.dtNewDuty.Copy(), "GS_DUTY", "UPDATE");
        }

        private void createNewDutyReport()
        {
            this.dtNewDuty.Columns.Add("WorkPlace");
            this.dtNewDuty.Columns.Add("WorkTime");
            this.dtNewDuty.Columns.Add("FirstName");
            this.dtNewDuty.Columns.Add("LastName");
            this.dtNewDuty.Columns.Add("DutyStatus");

            string postID_local = "";
            string shiftID_local = "";
            string gaurdID_local = "";

            DataTable dtGaurdInfo_local;
            DataTable dtPostInfo_local;
            DataTable dtShiftInfo_local;

            for (int dutyRC = 0; dutyRC <= this.dtNewDuty.Rows.Count - 1; dutyRC++)
            {
                postID_local = this.dtNewDuty.Rows[dutyRC]["GS_POST_ID"].ToString();
                shiftID_local = this.dtNewDuty.Rows[dutyRC]["GS_SHIFT_ID"].ToString();
                gaurdID_local = this.dtNewDuty.Rows[dutyRC]["GS_GAURD_ID"].ToString();

                if (postID_local != "" && shiftID_local != "")
                {
                    dtPostInfo_local =
                        this.getDataFromDB.getGS_POSTInfo(null, "", postID_local,
                            "", "", false, false, "AND");

                    dtShiftInfo_local =
                        this.getDataFromDB.getGS_SHIFTInfo(null, "", shiftID_local,
                            "", "", false, false, "AND");

                    if (this.getDataFromDB.checkIfTableContainesData(dtPostInfo_local) &&
                        this.getDataFromDB.checkIfTableContainesData(dtPostInfo_local))
                    {
                        this.dtNewDuty.Rows[dutyRC]["WorkPlace"] =
                            dtShiftInfo_local.Rows[0]["NAME"].ToString() + " - " +
                            dtPostInfo_local.Rows[0]["NAME"].ToString();

                        this.dtNewDuty.Rows[dutyRC]["WorkTime"] =
                            DateTime.Parse(dtShiftInfo_local.Rows[0]["STARTTIME"].ToString()).ToString("hh tt").Replace(" ", "") + " - " +
                            DateTime.Parse(dtShiftInfo_local.Rows[0]["ENDTIME"].ToString()).ToString("hh tt").Replace(" ", "");
                    }
                }

                if (gaurdID_local != "")
                {
                    dtGaurdInfo_local = this.getDataFromDB.getGS_GAURDInfo(null, "",
                            gaurdID_local, "", "", "", false, false, "AND");

                    if (this.getDataFromDB.checkIfTableContainesData(dtGaurdInfo_local))
                    {
                        this.dtNewDuty.Rows[dutyRC]["FirstName"] =
                            dtGaurdInfo_local.Rows[0]["FIRSTNAME"].ToString();
                        this.dtNewDuty.Rows[dutyRC]["LastName"] =
                            dtGaurdInfo_local.Rows[0]["MIDDELNAME"].ToString();
                    }
                }

                this.dtNewDuty.Rows[dutyRC]["DUTYDATE"] =
                    DateTime.Parse(this.dtNewDuty.Rows[dutyRC]["DUTYDATE"].ToString()).ToString("dd-MMM-yyyy");

                if (this.dtNewDuty.Rows[dutyRC]["ISONDUTY"].ToString() == "Y")
                    this.dtNewDuty.Rows[dutyRC]["DutyStatus"] = "On Duty";
                else
                    this.dtNewDuty.Rows[dutyRC]["DutyStatus"] = "Off Duty";
            }
        }



        #region "Create Duty Assignment Table"


        private bool isDateExluded(DateTime date)
        {
            bool dateIsExcluded = false;

            DataTable dtExclusion_local;
            DataTable dtDayExclusion_local;

            dtExclusion_local =
               this.getDataFromDB.getGS_EXCLUSIONInfo(null, "", "", "", "",
                        triaStateBool.Ignor, triaStateBool.Ignor, triaStateBool.Ignor,
                        triaStateBool.no, triaStateBool.no, triaStateBool.no,
                        true, false, "AND");


            DateTime startDate = DateTime.Now.AddYears(1);
            DateTime endDate = DateTime.Now.AddYears(1);

            string stFromDate;
            string stEndDate;
            string stDayOfDate = date.ToString("ddd");

            bool isDateExcluded = false;
            bool isDayExcluded = false;

            for (int exclusionRC = 0; exclusionRC <= dtExclusion_local.Rows.Count - 1; exclusionRC++)
            {
                isDateExcluded = false;

                // Check If Date is Excluded
                if (dtExclusion_local.Rows[exclusionRC]["ISDATE_EXCLUSION"].ToString() == "Y")
                {
                    stFromDate =
                        dtExclusion_local.Rows[exclusionRC]["EXCLUSION_DATE_BEGIN"].ToString();
                    stEndDate =
                        dtExclusion_local.Rows[exclusionRC]["EXCULSION_DATE_END"].ToString();

                    if (stFromDate != "")
                        startDate =
                            DateTime.Parse(stFromDate);

                    if (stEndDate != "")
                        endDate =
                            DateTime.Parse(stFromDate);

                    if (dtExclusion_local.Rows[exclusionRC]["ISRANGE_EXCLUSION"].ToString() == "Y")
                    {
                        //IF Date is inside specifed beging end date .. 
                        // then DATE is Excluded
                        if (stFromDate != "" && stEndDate != "")
                        {
                            if (startDate.Date.CompareTo(date.Date) != -1 &&
                                endDate.Date.CompareTo(date.Date) != 1)
                                isDateExcluded = true;
                        }
                        //IF Date is earlier-than or same-as specifed end date .. 
                        // then DATE is Excluded
                        if (stEndDate != "")
                        {
                            if (endDate.Date.CompareTo(date.Date) != 1)
                                isDateExcluded = true;
                        }
                        //IF Date is later-than or same-as specifed begin date .. 
                        // then DATE is Excluded
                        if (stFromDate != "")
                        {
                            if (startDate.Date.CompareTo(date.Date) != -1)
                                isDateExcluded = true;
                        }
                    }
                    else
                    {
                        //IF Date is same-as specifed date .. 
                        // then DATE is Excluded
                        if (startDate.Date.CompareTo(date.Date) == 0)
                            isDateExcluded = true;
                    }

                    //If Exclusion dectates The Combination of Day In A date Range and...
                    // the given date is Outside the Exclusion Range ... 
                    // then continue to the next exclusion
                    if (dtExclusion_local.Rows[exclusionRC]["ISDAY_DATE_COMBINATION"].ToString() == "Y")
                    {
                        if (!isDateExcluded)
                            continue;
                    }
                }

                // If Exclusion is not the combination of Day and Date and...
                // then Exclude the shift
                if (dtExclusion_local.Rows[exclusionRC]["ISDAY_DATE_COMBINATION"].ToString() == "N" &&
                    isDateExcluded)
                {
                    dateIsExcluded = true;
                    break;
                }

                // Check if Current Day of Date Is Excludable
                isDayExcluded = false;
                if (dtExclusion_local.Rows[exclusionRC]["ISDAY_EXCLUSION"].ToString() == "Y")
                {
                    dtDayExclusion_local =
                        this.getDataFromDB.getGS_DAY_EXCLUSIONInfo(null, "",
                            dtExclusion_local.Rows[exclusionRC]["GS_EXCLUSION_ID"].ToString(),
                            this.getCorrespondingDayOfWeek(stDayOfDate),
                            true, false, "AND");

                    if (this.getDataFromDB.checkIfTableContainesData(dtDayExclusion_local))
                        isDayExcluded = true;
                }

                // If Exclusion is not the combination of Day and Date and...
                // then Exclude the shift
                if (dtExclusion_local.Rows[exclusionRC]["ISDAY_DATE_COMBINATION"].ToString() == "N" &&
                    isDayExcluded)
                {
                    dateIsExcluded = true;
                    break;
                }

                if (dtExclusion_local.Rows[exclusionRC]["ISDAY_DATE_COMBINATION"].ToString() == "Y" &&
                    isDayExcluded && isDateExcluded)
                {
                    dateIsExcluded = true;
                    break;
                }
            }

            return dateIsExcluded;
        }

        private bool isPostExluded(DateTime date, string postID)
        {
            bool postIsExcluded = false;

            DataTable dtExclusion_local;
            DataTable dtDayExclusion_local;
            DataTable dtPostExclusion_local;

            // Check If Post has Exclusion On provided date/Day.

            dtPostExclusion_local =
                this.getDataFromDB.getGS_POST_EXCLUSIONInfo(null, "", "",
                    postID, true, false, "AND");

            dtExclusion_local =
                this.getDataFromDB.getGS_EXCLUSIONInfo(null, "", "",
                    triaStateBool.no, triaStateBool.no,
                    triaStateBool.yes, true, false, "AND");


            dtExclusion_local =
                this.getDataFromDB.mergeTables(dtExclusion_local, dtPostExclusion_local,
                    "GS_EXCLUSION_ID", true);


            DateTime startDate = DateTime.Now.AddYears(1);
            DateTime endDate = DateTime.Now.AddYears(1);

            string stFromDate;
            string stEndDate;
            string stDayOfDate = date.ToString("ddd");

            bool isDateExcluded = false;
            bool isDayExcluded = false;

            for (int exclusionRC = 0; exclusionRC <= dtExclusion_local.Rows.Count - 1; exclusionRC++)
            {
                isDateExcluded = false;

                // Check If Date is Excluded
                if (dtExclusion_local.Rows[exclusionRC]["ISDATE_EXCLUSION"].ToString() == "Y")
                {
                    stFromDate =
                        dtExclusion_local.Rows[exclusionRC]["EXCLUSION_DATE_BEGIN"].ToString();
                    stEndDate =
                        dtExclusion_local.Rows[exclusionRC]["EXCULSION_DATE_END"].ToString();

                    if (stFromDate != "")
                        startDate =
                            DateTime.Parse(stFromDate);

                    if (stEndDate != "")
                        endDate =
                            DateTime.Parse(stFromDate);

                    if (dtExclusion_local.Rows[exclusionRC]["ISRANGE_EXCLUSION"].ToString() == "Y")
                    {
                        //IF Date is inside specifed beging end date .. 
                        // then DATE is Excluded
                        if (stFromDate != "" && stEndDate != "")
                        {
                            if (startDate.Date.CompareTo(date.Date) != -1 &&
                                endDate.Date.CompareTo(date.Date) != 1)
                                isDateExcluded = true;
                        }
                        //IF Date is earlier-than or same-as specifed end date .. 
                        // then DATE is Excluded
                        if (stEndDate != "")
                        {
                            if (endDate.Date.CompareTo(date.Date) != 1)
                                isDateExcluded = true;
                        }
                        //IF Date is later-than or same-as specifed begin date .. 
                        // then DATE is Excluded
                        if (stFromDate != "")
                        {
                            if (startDate.Date.CompareTo(date.Date) != -1)
                                isDateExcluded = true;
                        }
                    }
                    else
                    {
                        //IF Date is same-as specifed date .. 
                        // then DATE is Excluded
                        if (startDate.Date.CompareTo(date.Date) == 0)
                            isDateExcluded = true;
                    }

                    //If Current Post Exclusion dectates The Combination of Day In A date Range and...
                    // the given date is Outside the Exclusion Range ... 
                    // then continue to the next exclusion
                    if (dtExclusion_local.Rows[exclusionRC]["ISDAY_DATE_COMBINATION"].ToString() == "Y")
                    {
                        if (!isDateExcluded)
                            continue;
                    }
                }

                // If Current Post Exclusion is not the combination of Day and Date ...                
                // then Exclude the Post
                if (dtExclusion_local.Rows[exclusionRC]["ISDAY_DATE_COMBINATION"].ToString() == "N" &&
                    isDateExcluded)
                {
                    postIsExcluded = true;
                    break;
                }

                // Check if Current Day of Date Is Excludable
                isDayExcluded = false;
                if (dtExclusion_local.Rows[exclusionRC]["ISDAY_EXCLUSION"].ToString() == "Y")
                {
                    dtDayExclusion_local =
                        this.getDataFromDB.getGS_DAY_EXCLUSIONInfo(null, "",
                            dtExclusion_local.Rows[exclusionRC]["GS_EXCLUSION_ID"].ToString(),
                            this.getCorrespondingDayOfWeek(stDayOfDate),
                            true, false, "AND");

                    if (this.getDataFromDB.checkIfTableContainesData(dtDayExclusion_local))
                        isDayExcluded = true;
                }

                // If Current Post Exclusion is not the combination of Day and Date ....                
                // then Exclude the shift
                if (dtExclusion_local.Rows[exclusionRC]["ISDAY_DATE_COMBINATION"].ToString() == "N" &&
                    isDayExcluded)
                {
                    postIsExcluded = true;
                    break;
                }

                if (dtExclusion_local.Rows[exclusionRC]["ISDAY_DATE_COMBINATION"].ToString() == "Y" &&
                    isDayExcluded && isDateExcluded)
                {
                    postIsExcluded = true;
                    break;
                }
            }

            return postIsExcluded;
        }

        private bool isShiftExluded(DateTime date, string postID, string shiftID)
        {
            bool shiftIsExcluded = false;

            DataTable dtExclusion_local;
            DataTable dtDayExclusion_local;
            DataTable dtPostExclusion_local;
            DataTable dtShiftExclusion_local;


            // Check If Shift has Exclusion On provided date/Day AND/OR post

            dtShiftExclusion_local =
                this.getDataFromDB.getGS_SHIFT_EXCLUSIONInfo(null, "", "",
                shiftID, true, false, "AND");

            dtExclusion_local =
                this.getDataFromDB.getGS_EXCLUSIONInfo(null, "", "",
                    triaStateBool.no, triaStateBool.yes,
                    triaStateBool.Ignor, true, false, "AND");


            dtExclusion_local =
                this.getDataFromDB.mergeTables(dtExclusion_local, dtShiftExclusion_local,
                    "GS_EXCLUSION_ID", true);



            DateTime startDate = DateTime.Now.AddYears(1);
            DateTime endDate = DateTime.Now.AddYears(1);

            string stFromDate;
            string stEndDate;
            string stDayOfDate = date.ToString("ddd");

            bool isDateExcluded = false;
            bool isDayExcluded = false;

            for (int exclusionRC = 0; exclusionRC <= dtExclusion_local.Rows.Count - 1; exclusionRC++)
            {
                isDateExcluded = false;

                // Check If Date is Excluded
                if (dtExclusion_local.Rows[exclusionRC]["ISDATE_EXCLUSION"].ToString() == "Y")
                {
                    stFromDate =
                        dtExclusion_local.Rows[exclusionRC]["EXCLUSION_DATE_BEGIN"].ToString();
                    stEndDate =
                        dtExclusion_local.Rows[exclusionRC]["EXCULSION_DATE_END"].ToString();

                    if (stFromDate != "")
                        startDate =
                            DateTime.Parse(stFromDate);

                    if (stEndDate != "")
                        endDate =
                            DateTime.Parse(stFromDate);

                    if (dtExclusion_local.Rows[exclusionRC]["ISRANGE_EXCLUSION"].ToString() == "Y")
                    {
                        //IF Date is inside specifed beging end date .. 
                        // then DATE is Excluded
                        if (stFromDate != "" && stEndDate != "")
                        {
                            if (startDate.Date.CompareTo(date.Date) != -1 &&
                                endDate.Date.CompareTo(date.Date) != 1)
                                isDateExcluded = true;
                        }
                        //IF Date is earlier-than or same-as specifed end date .. 
                        // then DATE is Excluded
                        if (stEndDate != "")
                        {
                            if (endDate.Date.CompareTo(date.Date) != 1)
                                isDateExcluded = true;
                        }
                        //IF Date is later-than or same-as specifed begin date .. 
                        // then DATE is Excluded
                        if (stFromDate != "")
                        {
                            if (startDate.Date.CompareTo(date.Date) != -1)
                                isDateExcluded = true;
                        }
                    }
                    else
                    {
                        //IF Date is same-as specifed date .. 
                        // then DATE is Excluded
                        if (startDate.Date.CompareTo(date.Date) == 0)
                            isDateExcluded = true;
                    }

                    //If Exclusion dectates The Combination of Day In A date Range and...
                    // the given date is Outside the Exclusion Range ... 
                    // then continue to the next exclusion
                    if (dtExclusion_local.Rows[exclusionRC]["ISDAY_DATE_COMBINATION"].ToString() == "Y")
                    {
                        if (!isDateExcluded)
                            continue;
                    }
                }

                // If Exclusion is not the combination of Day and Date and...
                // If Date is excluded regardless of A Post...
                // then Exclude the shift
                if (dtExclusion_local.Rows[exclusionRC]["ISDAY_DATE_COMBINATION"].ToString() == "N" &&
                    isDateExcluded)
                {
                    if (dtExclusion_local.Rows[exclusionRC]["ISPOST_EXCLUSION"].ToString() == "N")
                    {
                        shiftIsExcluded = true;
                        break;
                    }
                    // If the Exclusion of a shift Depend on the Post ...
                    // then check for the post exclusion rule...
                    else
                        goto checkPostExclusion;
                }

                // Check if Current Day of Date Is Excludable
                isDayExcluded = false;
                if (dtExclusion_local.Rows[exclusionRC]["ISDAY_EXCLUSION"].ToString() == "Y")
                {
                    dtDayExclusion_local =
                        this.getDataFromDB.getGS_DAY_EXCLUSIONInfo(null, "",
                            dtExclusion_local.Rows[exclusionRC]["GS_EXCLUSION_ID"].ToString(),
                            this.getCorrespondingDayOfWeek(stDayOfDate),
                            true, false, "AND");

                    if (this.getDataFromDB.checkIfTableContainesData(dtDayExclusion_local))
                        isDayExcluded = true;
                }

                // If Exclusion is not the combination of Day and Date and...
                // If the Day of the Date is excluded regardless of A Post...
                // then Exclude the shift
                if (dtExclusion_local.Rows[exclusionRC]["ISDAY_DATE_COMBINATION"].ToString() == "N" &&
                    isDayExcluded)
                {
                    if (dtExclusion_local.Rows[exclusionRC]["ISPOST_EXCLUSION"].ToString() == "N")
                    {
                        shiftIsExcluded = true;
                        break;
                    }
                    else
                        // If the Exclusion of a shift Depend on the Post ...
                        // then check for the post exclusion rule...
                        goto checkPostExclusion;
                }

                if (dtExclusion_local.Rows[exclusionRC]["ISDAY_DATE_COMBINATION"].ToString() == "Y" &&
                    isDayExcluded && isDateExcluded)
                {
                    if (dtExclusion_local.Rows[exclusionRC]["ISPOST_EXCLUSION"].ToString() == "N")
                    {
                        shiftIsExcluded = true;
                        break;
                    }
                    else
                        // If the Exclusion of a shift Depend on the Post ...
                        // then check for the post exclusion rule...
                        goto checkPostExclusion;
                }

                continue;

            checkPostExclusion:

                // Since the only decsion variable for the Exclusion of The Shift is the Post
                // Check for exsitance of Post Exclusion rule...

                dtPostExclusion_local =
                    this.getDataFromDB.getGS_POST_EXCLUSIONInfo(null, "",
                            dtExclusion_local.Rows[exclusionRC]["GS_EXCLUSION_ID"].ToString(),
                            postID, true, false, "AND");

                if (this.getDataFromDB.checkIfTableContainesData(dtPostExclusion_local))
                {
                    shiftIsExcluded = true;
                    break;
                }
            }

            return shiftIsExcluded;
        }

        private void addNewDutyRow(DateTime date, string postID, string shiftID, string gaurdID)
        {
            try
            {
                DataRow drNewDuty = this.dtNewDuty.NewRow();
                drNewDuty["DUTYDATE"] = date;
                if (postID != "")
                    drNewDuty["GS_POST_ID"] = postID;
                if (shiftID != "")
                    drNewDuty["GS_SHIFT_ID"] = shiftID;
                if (gaurdID != "")
                    drNewDuty["GS_GAURD_ID"] = gaurdID;

                this.dtNewDuty.Rows.Add(drNewDuty);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Creating Schedule /n{ " + ex.Message +
                    " }. Generated Schedule May not be Correct. /n Please Contact Your Administrator",
                    "Generate Error", MessageBoxButtons.OK);
                return;
            }
        }


        private void createNewDutyAssignmentTable(DateTime startDate, DateTime endDate)
        {

            string stPostID = "";
            string stShiftID = "";

            DataTable dtAllActivePosts_local =
                this.getDataFromDB.getGS_POSTInfo(null, "", "",
                    "", "", true, false, "AND");

            DataTable dtAllActiveShifts_local =
                this.getDataFromDB.getGS_SHIFTInfo(null, "", "",
                    "", "", true, false, "AND");

            for (DateTime tm_date = startDate;
                tm_date <= endDate; tm_date = tm_date.AddDays(1))
            {
                if (this.isDateExluded(tm_date))
                    continue;

                for (int rowsInPost = 0;
                    rowsInPost <= this.dtAllActivePosts.Rows.Count - 1;
                    rowsInPost++)
                {
                    stPostID =
                        dtAllActivePosts_local.Rows[rowsInPost]["GS_POST_ID"].ToString();
                    if (this.isPostExluded(tm_date, stPostID))
                        continue;
                    for (int rowsInShift = 0;
                        rowsInShift <= this.dtAllActiveShifts.Rows.Count - 1;
                        rowsInShift++)
                    {
                        stShiftID =
                            dtAllActiveShifts_local.Rows[rowsInShift]["GS_SHIFT_ID"].ToString();
                        if (this.isShiftExluded(tm_date, stPostID, stShiftID))
                            continue;
                        this.addNewDutyRow(tm_date, stPostID, stShiftID, "");
                    }
                }
            }
        }

        private void createNewDutyAssignmentTable()
        {

            this.dtNewDuty =
                this.getDataFromDB.getGS_DUTY(null, "", "", DateTime.Now,
                    false, triaStateBool.Ignor, "", "", "",
                    "", false, true, "AND");

            string stPostID = "";
            string stShiftID = "";

            dtAllActivePosts =
                this.getDataFromDB.getGS_POSTInfo(null, "", "",
                    "", "", true, false, "AND");

            dtAllActiveShifts =
                this.getDataFromDB.getGS_SHIFTInfo(null, "", "",
                    "", "", true, false, "AND");

            for (DateTime tm_date = this.tm_ScheduleStartDate;
                tm_date <= tm_ScheduleEndDate; tm_date = tm_date.AddDays(1))
            {
                if (this.isDateExluded(tm_date))
                    continue;

                for (int rowsInPost = 0;
                    rowsInPost <= this.dtAllActivePosts.Rows.Count - 1;
                    rowsInPost++)
                {
                    stPostID =
                        this.dtAllActivePosts.Rows[rowsInPost]["GS_POST_ID"].ToString();
                    if (this.isPostExluded(tm_date, stPostID))
                        continue;
                    for (int rowsInShift = 0;
                        rowsInShift <= this.dtAllActiveShifts.Rows.Count - 1;
                        rowsInShift++)
                    {
                        stShiftID =
                            this.dtAllActiveShifts.Rows[rowsInShift]["GS_SHIFT_ID"].ToString();
                        if (this.isShiftExluded(tm_date, stPostID, stShiftID))
                            continue;
                        this.addNewDutyRow(tm_date, stPostID, stShiftID, "");
                    }
                }
            }
        }


        #endregion


        private void setUpLookUpTables()
        {
            //Get All Active Gaurds
            this.dtAllActiveGaurds =
                this.getDataFromDB.getGS_GAURDInfo(null, "", "",
                    "", "", "", true, false, "AND");

            //For Each Date In New Duty ....
            //Create Gaurd Assignment possibility Showing ...
            // 1. Whether Gaurd Could be assigned to each duty [DATE_POST_SHIFT combination]....
            //Or not ....(Based On Rule Of Exclusion and Business Logic)
            // 2. The preference index of a Gaurd to given DUTY.
            // 3. Whether a A Gaurd Is Assigned a DUTY or not.


            this.dtDailyDutyPossibiltySheet =
                this.getDataFromDB.getGS_DUTY(null, "", "", DateTime.Now, false,
                        triaStateBool.Ignor, "", "", "", "", false, true, "AND");

            //PR_INDEX := Gaurd Preference Index for a duty.
            //AV_INDEX := Gaurd Availablity Index for a duty.
            this.dtDailyDutyPossibiltySheet.Columns.Add("PR_INDEX", Type.GetType("System.Int32"));
            this.dtDailyDutyPossibiltySheet.Columns.Add("AV_INDEX", Type.GetType("System.Int32"));

            //Create Gaurd Availabitly Sheet Showing....
            // each Duty's total count of Gaurds available.
            this.dtDailyGardAvailbitlySheet.Clear();
            if (this.dtDailyGardAvailbitlySheet.Columns.Count < 1)
            {
                this.dtDailyGardAvailbitlySheet.Columns.Add("GS_POST_ID", Type.GetType("System.Int32"));
                this.dtDailyGardAvailbitlySheet.Columns.Add("GS_SHIFT_ID", Type.GetType("System.Int32"));
                this.dtDailyGardAvailbitlySheet.Columns.Add("GAURDCOUNT", Type.GetType("System.Int32"));
                this.dtDailyGardAvailbitlySheet.Columns.Add("ISASSIGNED", Type.GetType("System.String"));
            }


            //Create Duty Availability Sheet Showing....
            // each Gaurd's total count of Duty/ies available.
            this.dtDailyDutyAvailbitlySheet.Clear();
            if (this.dtDailyDutyAvailbitlySheet.Columns.Count < 1)
            {
                this.dtDailyDutyAvailbitlySheet.Columns.Add("GS_GAURD_ID", Type.GetType("System.Int32"));
                this.dtDailyDutyAvailbitlySheet.Columns.Add("DUTYCOUNT", Type.GetType("System.Int32"));
                this.dtDailyDutyAvailbitlySheet.Columns.Add("ISASSIGNED", Type.GetType("System.String"));
            }

        }

        private void createAssingment(BackgroundWorker _backGrounWorker, int singleDayPrcIncrement)
        {
            DateTime tm_AssignemntSheetDate_lcoal = this.tm_ScheduleStartDate.AddYears(1);
            DateTime tm_NewDutyDate_lcoal = this.tm_ScheduleStartDate;

            this.tm_CurrentCycleBeggingDate =
                this.tm_ScheduleStartDate;

            this.tm_CurrentCycleEndingDate =
                        this.tm_CurrentCycleBeggingDate.
                                AddDays(this.intSheduleSingleCycle);

            this.tm_CurrentCycleEndingDate =
                this.tm_CurrentCycleEndingDate.Date.CompareTo(this.tm_ScheduleEndDate.Date) != 1 ?
                        this.tm_CurrentCycleEndingDate : this.tm_ScheduleEndDate;


            for (int dutyRC = 0; dutyRC <= this.dtNewDuty.Rows.Count - 1; dutyRC++)
            {
                tm_NewDutyDate_lcoal =
                    DateTime.Parse(this.dtNewDuty.Rows[dutyRC]["DUTYDATE"].ToString());

                if (this.dtNewDuty.Rows[dutyRC]["ISONDUTY"].ToString() != "")
                    continue;

                if (this.tm_CurrentCycleEndingDate.Date.CompareTo(tm_NewDutyDate_lcoal.Date) == -1)
                {
                    this.tm_CurrentCycleBeggingDate = tm_NewDutyDate_lcoal;
                    this.tm_CurrentCycleEndingDate =
                        this.tm_CurrentCycleBeggingDate.
                                AddDays(this.intSheduleSingleCycle);

                    this.tm_CurrentCycleEndingDate =
                        this.tm_CurrentCycleEndingDate.Date.CompareTo(this.tm_ScheduleEndDate.Date) != 1 ?
                                this.tm_CurrentCycleEndingDate : this.tm_ScheduleEndDate;

                }

                if (tm_NewDutyDate_lcoal.Date.CompareTo(tm_AssignemntSheetDate_lcoal.Date) != 0)
                {
                    tm_AssignemntSheetDate_lcoal = tm_NewDutyDate_lcoal;
                    this.tm_CurrentProcessingDate = tm_NewDutyDate_lcoal;
                    //this.writeToFile(this.tm_CurrentProcessingDate.ToString());
                    this.createAssignmentPossibiltySheet(tm_AssignemntSheetDate_lcoal);
                    this.createAvailabiltySheets();
                    this.selectGaurdDutyCombination();

                    DataView dvResult = this.dtNewDuty.DefaultView;

                    if (dvResult.Table.Columns.Contains("DUTYDATE"))
                        dvResult.Sort = "DUTYDATE ASC";

                    this.dtNewDuty = dvResult.ToTable();
                    //this.writeToFile("\n");
                    _backGrounWorker.ReportProgress(singleDayPrcIncrement);
                }
            }
        }

        public void beginGenerateSchedule(BackgroundWorker _backGrounWorker)
        {            
            //this.calculateSingleCycleDays();

            //this.cycleMidWay =
            //    int.Parse(Math.Floor(decimal.Parse(this.intSheduleSingleCycle.ToString()) / 2).ToString());

            _backGrounWorker.ReportProgress(1);
            this.tm_ScheduleStartDate = generalResultInformation.startDate;
            this.tm_ScheduleEndDate = generalResultInformation.EndDate;

            double totalNumberOfDays =
                this.tm_ScheduleEndDate.Date.AddDays(1).Subtract(this.tm_ScheduleStartDate.Date).TotalDays;

            int singleDayPrcIncrement =
                int.Parse(Math.Floor((1 / totalNumberOfDays) * 95).ToString());

            if (this.erraseExisting)
            {
                this.erraseExistingDutyAssignment();
            }
            else
            {
                this.fetchExistingDateRangeDutyAssignment(_backGrounWorker, singleDayPrcIncrement);
                if (this.getDataFromDB.checkIfTableContainesData(this.dtNewDuty))
                {
                    this.createNewDutyReport();

                    generalResultInformation.searchResult =
                        this.dtNewDuty;

                    _backGrounWorker.ReportProgress(100);
                    return;
                }
            }


            this.createNewDutyAssignmentTable();
            _backGrounWorker.ReportProgress(1);

            if (!this.getDataFromDB.checkIfTableContainesData(this.dtNewDuty))
            {
                _backGrounWorker.ReportProgress(95);
                goto saveAndFormatSchedule;
            }

            // Check Out this line

            this.calculateSingleCycleDays();

            this.cycleMidWay =
                int.Parse(Math.Floor(decimal.Parse(this.intSheduleSingleCycle.ToString()) / 2).ToString());


            this.setUpLookUpTables();

            this.createAssingment(_backGrounWorker, singleDayPrcIncrement);

        saveAndFormatSchedule:

            this.saveNewDutyInfo();
            this.createNewDutyReport();

            generalResultInformation.searchResult =
                this.dtNewDuty;

            _backGrounWorker.ReportProgress(3);
        }



        private void createAssignmentPossibiltySheet(DateTime date)
        {
            if (!this.getDataFromDB.checkIfTableContainesData(this.dtNewDuty))
                return;

            string postID = "";
            string shiftID = "";
            string gaurdID = "";

            DateTime dutyShtDate = DateTime.Now;


            this.createDutyAvailabiltySheet();
            this.createGaurdAvailabiltySheet();

            this.dtDailyDutyPossibiltySheet.Rows.Clear();

            //wr_2("DUTYDATE,GS_POST_ID,GS_SHIFT_ID,GS_GAURD_ID,AV_INDEX,PR_INDEX");

            for (int dutyShtRC = 0; dutyShtRC <= this.dtNewDuty.Rows.Count - 1; dutyShtRC++)
            {
                dutyShtDate =
                    DateTime.Parse(this.dtNewDuty.Rows[dutyShtRC]["DUTYDATE"].ToString());
                if (dutyShtDate.Date.CompareTo(date.Date) != 0)
                    continue;

                postID =
                    this.dtNewDuty.Rows[dutyShtRC]["GS_POST_ID"].ToString();
                shiftID =
                    this.dtNewDuty.Rows[dutyShtRC]["GS_SHIFT_ID"].ToString();

                for (int gardRC = 0; gardRC <= this.dtAllActiveGaurds.Rows.Count - 1; gardRC++)
                {
                    gaurdID =
                        this.dtAllActiveGaurds.Rows[gardRC]["GS_GAURD_ID"].ToString();

                    DataRow drNewDutyAssignmentSheet =
                        this.dtDailyDutyPossibiltySheet.NewRow();
                    drNewDutyAssignmentSheet["DUTYDATE"] = date;
                    drNewDutyAssignmentSheet["GS_POST_ID"] = postID;
                    drNewDutyAssignmentSheet["GS_SHIFT_ID"] = shiftID;
                    drNewDutyAssignmentSheet["GS_GAURD_ID"] = gaurdID;

                    if (this.isGaurdAvailableForDuty(date, postID, shiftID, gaurdID))
                        drNewDutyAssignmentSheet["AV_INDEX"] = 1;
                    else
                        drNewDutyAssignmentSheet["AV_INDEX"] = 0;

                    drNewDutyAssignmentSheet["PR_INDEX"] =
                        this.getGaurdPreferenceIdex(date, postID, shiftID, gaurdID);

                    //wr_2(drNewDutyAssignmentSheet["DUTYDATE"].ToString() + "," +
                    //         drNewDutyAssignmentSheet["GS_POST_ID"].ToString() + "," +
                    //         drNewDutyAssignmentSheet["GS_SHIFT_ID"].ToString() + "," +
                    //         drNewDutyAssignmentSheet["GS_GAURD_ID"].ToString() + "," +
                    //         drNewDutyAssignmentSheet["AV_INDEX"].ToString() + "," +
                    //         drNewDutyAssignmentSheet["PR_INDEX"].ToString() + ","
                    //         );

                    this.dtDailyDutyPossibiltySheet.Rows.Add(drNewDutyAssignmentSheet);
                }
            }
        }

        //No reptition of duty in same cycle
        private bool isDutyReptitionInCycle(string postID,
            string shiftID, string gaurdID)
        {
            bool blDutyExists = false;

            DateTime dutyDate_local;

            for (int dutyRC = 0; dutyRC <= this.dtNewDuty.Rows.Count - 1; dutyRC++)
            {
                dutyDate_local =
                    DateTime.Parse(this.dtNewDuty.Rows[dutyRC]["DUTYDATE"].ToString());
                if (this.tm_CurrentCycleBeggingDate.Date.CompareTo(dutyDate_local.Date) == 1)
                    continue;

                if (this.tm_CurrentCycleEndingDate.Date.CompareTo(dutyDate_local.Date) == -1)
                    continue;

                if (postID == this.dtNewDuty.Rows[dutyRC]["GS_POST_ID"].ToString() &&
                    shiftID == this.dtNewDuty.Rows[dutyRC]["GS_SHIFT_ID"].ToString() &&
                    gaurdID == this.dtNewDuty.Rows[dutyRC]["GS_GAURD_ID"].ToString())
                {
                    blDutyExists = true;
                    break;
                }
            }

            return blDutyExists;
        }

        //No consequetive Shift In two consequetive Days I.e No Night Shift Goes Day
        private bool isShiftsConsequtive(string shiftID_1, string shiftID_2)
        {

            if ((shiftID_1 == "" || this.isNightShift(shiftID_1)) &&
                this.isDayShift(shiftID_2))
                return true;
            else
                return false;

            /*
                      
            bool blShiftIsConsequetive = false; 
            DataTable dtShiftInfo_local =
                this.getDataFromDB.getGS_SHIFTInfo(null, "", shiftID_1,
                    "", "", false, false, "AND");

            if (!this.getDataFromDB.checkIfTableContainesData(dtShiftInfo_local))
                return false;

            DateTime shift_1StartHour =
                DateTime.Parse(dtShiftInfo_local.Rows[0]["STARTTIME"].ToString());

            DateTime shift_1EndHour =
                DateTime.Parse(dtShiftInfo_local.Rows[0]["ENDTIME"].ToString());

            dtShiftInfo_local =
                this.getDataFromDB.getGS_SHIFTInfo(null, "", shiftID_2,
                    "", "", false, false, "AND");

            if (!this.getDataFromDB.checkIfTableContainesData(dtShiftInfo_local))
                return false;

            DateTime shift_2StartHour =
               DateTime.Parse(dtShiftInfo_local.Rows[0]["STARTTIME"].ToString());

            DateTime shift_2EndHour =
                DateTime.Parse(dtShiftInfo_local.Rows[0]["ENDTIME"].ToString());

//            if((Math.Abs((shift_1EndHour.TimeOfDay - shift_2StartHour.TimeOfDay).Hours) >= 5) 
             
             return blShiftIsConsequetive;            

            */

        }

        //No Gaurd On Exclusion Rule
        private bool isGardExcluded(DateTime dutyDate, string postID,
            string shiftID, string gaurdID)
        {
            bool gaurdIsExcluded = false;

            DataTable dtExclusion_local;
            DataTable dtDayExclusion_local;
            DataTable dtPostExclusion_local;
            DataTable dtShiftExclusion_local;
            DataTable dtGaurdExclusion_local;


            // Check If Shift has Exclusion On provided date/Day AND/OR post

            dtGaurdExclusion_local =
                this.getDataFromDB.getGS_GAURD_EXCLUSIONInfo(null, "", "",
                    shiftID, true, false, "AND");

            dtExclusion_local =
                this.getDataFromDB.getGS_EXCLUSIONInfo(null, "", "",
                    triaStateBool.yes, triaStateBool.Ignor,
                    triaStateBool.Ignor, true, false, "AND");

            dtExclusion_local =
                this.getDataFromDB.mergeTables(dtExclusion_local, dtExclusion_local,
                        "GS_EXCLUSION_ID", true);



            DateTime startDate = DateTime.Now.AddYears(1);
            DateTime endDate = DateTime.Now.AddYears(1);

            DateTime date = dutyDate;

            string stFromDate;
            string stEndDate;
            string stDayOfDate = date.ToString("ddd");

            bool isDateExcluded = false;
            bool isDayExcluded = false;

            for (int exclusionRC = 0; exclusionRC <= dtExclusion_local.Rows.Count - 1; exclusionRC++)
            {
                isDateExcluded = false;

                // Check If Date is Excluded
                if (dtExclusion_local.Rows[exclusionRC]["ISDATE_EXCLUSION"].ToString() == "Y")
                {
                    stFromDate =
                        dtExclusion_local.Rows[exclusionRC]["EXCLUSION_DATE_BEGIN"].ToString();
                    stEndDate =
                        dtExclusion_local.Rows[exclusionRC]["EXCULSION_DATE_END"].ToString();

                    if (stFromDate != "")
                        startDate =
                            DateTime.Parse(stFromDate);

                    if (stEndDate != "")
                        endDate =
                            DateTime.Parse(stFromDate);

                    if (dtExclusion_local.Rows[exclusionRC]["ISRANGE_EXCLUSION"].ToString() == "Y")
                    {
                        //IF Date is inside specifed beging end date .. 
                        // then DATE is Excluded
                        if (stFromDate != "" && stEndDate != "")
                        {
                            if (startDate.Date.CompareTo(date.Date) != -1 &&
                                endDate.Date.CompareTo(date.Date) != 1)
                                isDateExcluded = true;
                        }
                        //IF Date is earlier-than or same-as specifed end date .. 
                        // then DATE is Excluded
                        if (stEndDate != "")
                        {
                            if (endDate.Date.CompareTo(date.Date) != 1)
                                isDateExcluded = true;
                        }
                        //IF Date is later-than or same-as specifed begin date .. 
                        // then DATE is Excluded
                        if (stFromDate != "")
                        {
                            if (startDate.Date.CompareTo(date.Date) != -1)
                                isDateExcluded = true;
                        }
                    }
                    else
                    {
                        //IF Date is same-as specifed date .. 
                        // then DATE is Excluded
                        if (startDate.Date.CompareTo(date.Date) == 0)
                            isDateExcluded = true;
                    }

                    //If Exclusion dectates The Combination of Day In A date Range and...
                    // the given date is Outside the Exclusion Range ... 
                    // then continue to the next exclusion
                    if (dtExclusion_local.Rows[exclusionRC]["ISDAY_DATE_COMBINATION"].ToString() == "Y")
                    {
                        if (!isDateExcluded)
                            continue;
                    }
                }

                // If Exclusion is not the combination of Day and Date and...
                // If Date is excluded regardless of A Post AND/OR A Shift...
                // then Exclude the Gaurd
                if (dtExclusion_local.Rows[exclusionRC]["ISDAY_DATE_COMBINATION"].ToString() == "N" &&
                    isDateExcluded)
                {
                    if (dtExclusion_local.Rows[exclusionRC]["ISPOST_EXCLUSION"].ToString() == "N" &&
                        dtExclusion_local.Rows[exclusionRC]["ISSHIFT_EXCLUSION"].ToString() == "N")
                    {
                        gaurdIsExcluded = true;
                        break;
                    }
                    // If the Exclusion of a Gaurd Depend on the Post AND/OR Shift ...
                    // then check for the post and shift exclusion rule...
                    else
                        goto checkPostAndShiftExclusion;
                }

                // Check if Current Day of Date Is Excludable
                isDayExcluded = false;
                if (dtExclusion_local.Rows[exclusionRC]["ISDAY_EXCLUSION"].ToString() == "Y")
                {
                    dtDayExclusion_local =
                        this.getDataFromDB.getGS_DAY_EXCLUSIONInfo(null, "",
                            dtExclusion_local.Rows[exclusionRC]["GS_EXCLUSION_ID"].ToString(),
                            this.getCorrespondingDayOfWeek(stDayOfDate),
                            true, false, "AND");

                    if (this.getDataFromDB.checkIfTableContainesData(dtDayExclusion_local))
                        isDayExcluded = true;
                }

                // If Exclusion is not the combination of Day and Date and...
                // If the Day of the Date is excluded regardless of A Post...
                // then Exclude the shift
                if (dtExclusion_local.Rows[exclusionRC]["ISDAY_DATE_COMBINATION"].ToString() == "N" &&
                    isDayExcluded)
                {
                    if (dtExclusion_local.Rows[exclusionRC]["ISPOST_EXCLUSION"].ToString() == "N" &&
                        dtExclusion_local.Rows[exclusionRC]["ISSHIFT_EXCLUSION"].ToString() == "N")
                    {
                        gaurdIsExcluded = true;
                        break;
                    }
                    else
                        // If the Exclusion of a Gaurd Depend on the Post AND/OR SHIFT ...
                        // then check for the post exclusion rule...
                        goto checkPostAndShiftExclusion;
                }

                if (dtExclusion_local.Rows[exclusionRC]["ISDAY_DATE_COMBINATION"].ToString() == "Y" &&
                    isDayExcluded && isDateExcluded)
                {
                    if (dtExclusion_local.Rows[exclusionRC]["ISPOST_EXCLUSION"].ToString() == "N" &&
                        dtExclusion_local.Rows[exclusionRC]["ISSHIFT_EXCLUSION"].ToString() == "N")
                    {
                        gaurdIsExcluded = true;
                        break;
                    }
                    else
                        // If the Exclusion of a Gaurd Depend on the Post AND/POST ...
                        // then check for the post exclusion rule...
                        goto checkPostAndShiftExclusion;
                }

                continue;

            checkPostAndShiftExclusion:

                // Since the only decsion variables remaining for the Exclusion of The Gaurd are ...
                // the Post and shift.....
                // Check for exsitance of Post and/or Shift Exclusion rule...
                bool postIsExcluded = false;
                if (dtExclusion_local.Rows[exclusionRC]["ISPOST_EXCLUSION"].ToString() == "Y")
                {
                    dtPostExclusion_local =
                        this.getDataFromDB.getGS_POST_EXCLUSIONInfo(null, "",
                                dtExclusion_local.Rows[exclusionRC]["GS_EXCLUSION_ID"].ToString(),
                                postID, true, false, "AND");
                    if (this.getDataFromDB.checkIfTableContainesData(dtPostExclusion_local))
                    {
                        if (dtExclusion_local.Rows[exclusionRC]["ISSHIFT_EXCLUSION"].ToString() == "N")
                        {
                            gaurdIsExcluded = true;
                            break;
                        }
                        else
                            postIsExcluded = true;
                    }
                }


                if (dtExclusion_local.Rows[exclusionRC]["ISSHIFT_EXCLUSION"].ToString() == "Y")
                {
                    dtShiftExclusion_local =
                        this.getDataFromDB.getGS_SHIFT_EXCLUSIONInfo(null, "",
                                dtExclusion_local.Rows[exclusionRC]["GS_EXCLUSION_ID"].ToString(),
                                shiftID, true, false, "AND");
                    if (this.getDataFromDB.checkIfTableContainesData(dtShiftExclusion_local))
                    {
                        if (dtExclusion_local.Rows[exclusionRC]["ISPOST_EXCLUSION"].ToString() == "N" ||
                            postIsExcluded)
                        {
                            gaurdIsExcluded = true;
                            break;
                        }
                    }
                }
            }

            return gaurdIsExcluded;
        }

        //Fetchs nth Last Duty of the Gaurd in preceeding Assignments.
        /// <summary>
        /// Fetchs nth Last Duty of the Gaurd in preceeding Assignments. 
        /// </summary>
        /// <param name="gaurdID">The Gaurd's Primary Key ID</param>
        /// <param name="fromDate">The Date from which to preceed</param>
        /// <param name="dutyIndex">The Number of Previous Duty Assignments to disregard</param>
        /// <param name="inCurrentCycle">Fetch Result From The current cycle</param>
        /// <param name="onlyOnDuties">Consider Only Duty Assignments With Active Status</param>
        /// <returns>Data Table</returns>
        private DataTable getThe_Nth_PreviousDuty(string gaurdID, DateTime fromDate, int dutyIndex,
            bool onlyInCurrentCycle, bool onlyOnDuties, bool onlyOutSideCurrentCycle)
        {
            DataTable dutyInfo_local = this.dtNewDuty.Clone();

            if (dutyIndex < 0)
                return dutyInfo_local;

            if (onlyInCurrentCycle)
            {
                if ((this.tm_CurrentCycleBeggingDate.Date.CompareTo(fromDate.Date) == 1) ||
                    this.tm_CurrentCycleEndingDate.Date.CompareTo(fromDate.Date) == -1)
                    return dutyInfo_local;
            }

            DateTime dutyDate_local = fromDate;

            if (this.tm_ScheduleStartDate.Date.CompareTo(fromDate.Date) != 1 &&
                this.tm_ScheduleEndDate.Date.CompareTo(fromDate.Date) != -1)
            {

                for (int dutyRC = this.dtNewDuty.Rows.Count - 1; dutyRC >= 0; dutyRC--)
                {
                    dutyDate_local =
                        DateTime.Parse(this.dtNewDuty.Rows[dutyRC]["DUTYDATE"].ToString());

                    if (onlyInCurrentCycle)
                    {
                        if (this.tm_CurrentCycleBeggingDate.Date.CompareTo(dutyDate_local.Date) == 1)
                            continue;

                        if (this.tm_CurrentCycleEndingDate.Date.CompareTo(dutyDate_local.Date) == -1)
                            continue;
                    }

                    if (onlyOutSideCurrentCycle)
                    {
                        if (this.tm_CurrentCycleBeggingDate.Date.CompareTo(dutyDate_local.Date) == -1)
                            continue;

                        if (this.tm_CurrentCycleEndingDate.Date.CompareTo(dutyDate_local.Date) == 1)
                            continue;
                    }

                    if (fromDate.Date.CompareTo(dutyDate_local.Date) != 1)
                        continue;

                    if (this.dtNewDuty.Rows[dutyRC]["ISONDUTY"].ToString() == "N" &&
                        onlyOnDuties)
                        continue;

                    if (gaurdID == this.dtNewDuty.Rows[dutyRC]["GS_GAURD_ID"].ToString() && dutyIndex == 0)
                    {
                        DataRow drDutyInfo = dutyInfo_local.NewRow();
                        for (int dutyCC = 0; dutyCC <= this.dtNewDuty.Columns.Count - 1; dutyCC++)
                        {
                            drDutyInfo[dutyCC] =
                                this.dtNewDuty.Rows[dutyRC][dutyCC];
                        }
                        dutyInfo_local.Rows.Add(drDutyInfo);
                        return dutyInfo_local;
                    }
                    else if (gaurdID == this.dtNewDuty.Rows[dutyRC]["GS_GAURD_ID"].ToString())
                    {
                        dutyIndex--;
                    }
                }
            }

            dutyDate_local = dutyDate_local.AddDays(-1);

            if (onlyInCurrentCycle)
                return dutyInfo_local;

            DataTable allDutInfoforGard =
                this.getDataFromDB.getGS_DUTY(null, "", "", DateTime.Now, false,
                        onlyOnDuties ? triaStateBool.yes : triaStateBool.Ignor,
                        "", "", gaurdID, "", true, false, "AND");

            if (!this.getDataFromDB.checkIfTableContainesData(allDutInfoforGard))
                return dutyInfo_local;

            int totalDutyCountOfGaurd = allDutInfoforGard.Rows.Count;

            while (dutyIndex >= 0 && totalDutyCountOfGaurd > 0)
            {
                dutyInfo_local =
                    this.getDataFromDB.getGS_DUTY(null, "", dutyDate_local, gaurdID,
                        onlyOnDuties ? triaStateBool.yes : triaStateBool.Ignor,
                        true, "AND");
                if (this.getDataFromDB.checkIfTableContainesData(dutyInfo_local))
                    dutyIndex--;

                totalDutyCountOfGaurd--;
                dutyDate_local = dutyDate_local.AddDays(-1);
            };

            return dutyInfo_local;
        }

        private DataTable getThe_Nth_PreviousDuty(string gaurdID, DateTime fromDate, int dutyIndex, bool onlyInCurrentCycle, bool onlyOnDuties)
        {
            return this.getThe_Nth_PreviousDuty(gaurdID, fromDate, dutyIndex, onlyInCurrentCycle,
                onlyOnDuties, false);
        }


        private string getPreviousOffCycleShift(string gaurdID, DateTime datePriorTo)
        {
            return this.getTheNthPreviousOffCycleShift(gaurdID, datePriorTo, 0);
        }

        private string getPreviousInCycleShift(string gaurdID, DateTime datePriorTo)
        {
            return this.getTheNthPreviousInCycleShift(gaurdID, datePriorTo, 0);
        }

        private string getPreviousShift(string gaurdID, DateTime datePriorTo)
        {
            return this.getTheNthPreviousShift(gaurdID, datePriorTo, 0);

        }



        private string getTheNthPreviousInCycleShift(string gaurdID, DateTime datePriorTo, int dutyIndex)
        {
            string shiftID = "";

            DataTable prvShift =
                this.getThe_Nth_PreviousDuty(gaurdID, datePriorTo, dutyIndex, true, false, false);

            if (this.getDataFromDB.checkIfTableContainesData(prvShift))
            {
                shiftID = prvShift.Rows[0]["GS_SHIFT_ID"].ToString();
                shiftID = shiftID == "" ? offDutyShiftkey : shiftID;
                return shiftID;
            }
            else
                return newGaurdkey;
        }

        private string getTheNthPreviousOffCycleShift(string gaurdID, DateTime datePriorTo, int dutyIndex)
        {
            string shiftID = "";

            DataTable prvShift =
                this.getThe_Nth_PreviousDuty(gaurdID, datePriorTo, dutyIndex, false, false, true);

            if (this.getDataFromDB.checkIfTableContainesData(prvShift))
            {
                shiftID = prvShift.Rows[0]["GS_SHIFT_ID"].ToString();
                shiftID = shiftID == "" ? offDutyShiftkey : shiftID;
                return shiftID;
            }
            else
                return newGaurdkey;
        }

        private string getTheNthPreviousShift(string gaurdID, DateTime datePriorTo, int dutyIndex)
        {
            string shiftID = "";

            DataTable prvShift =
                this.getThe_Nth_PreviousDuty(gaurdID, datePriorTo, dutyIndex, false, false, false);

            if (this.getDataFromDB.checkIfTableContainesData(prvShift))
            {
                shiftID = prvShift.Rows[0]["GS_SHIFT_ID"].ToString();
                shiftID = shiftID == "" ? offDutyShiftkey : shiftID;
                return shiftID;
            }
            else
                return newGaurdkey;
        }



        private string getTheNthPreviousOnDutyInCylceShift(string gaurdID, DateTime datePriorTo, int dutyIndex)
        {
            string shiftID = "";

            DataTable prvShift =
                this.getThe_Nth_PreviousDuty(gaurdID, datePriorTo, dutyIndex, true, true, false);

            if (this.getDataFromDB.checkIfTableContainesData(prvShift))
            {
                shiftID = prvShift.Rows[0]["GS_SHIFT_ID"].ToString();
                shiftID = shiftID == "" ? offDutyShiftkey : shiftID;
                return shiftID;
            }
            else
                return newGaurdkey;
        }

        private string getTheNthPreviousOnDutyOffCylceShift(string gaurdID, DateTime datePriorTo, int dutyIndex)
        {
            string shiftID = "";

            DataTable prvShift =
                this.getThe_Nth_PreviousDuty(gaurdID, datePriorTo, dutyIndex, false, true, true);

            if (this.getDataFromDB.checkIfTableContainesData(prvShift))
            {
                shiftID = prvShift.Rows[0]["GS_SHIFT_ID"].ToString();
                shiftID = shiftID == "" ? offDutyShiftkey : shiftID;
                return shiftID;
            }
            else
                return newGaurdkey;
        }

        private string getTheNthPreviouOnDutyShift(string gaurdID, DateTime datePriorTo, int dutyIndex)
        {
            string shiftID = "";

            DataTable prvShift =
                this.getThe_Nth_PreviousDuty(gaurdID, datePriorTo, dutyIndex, false, true, false);

            if (this.getDataFromDB.checkIfTableContainesData(prvShift))
            {
                shiftID = prvShift.Rows[0]["GS_SHIFT_ID"].ToString();
                shiftID = shiftID == "" ? offDutyShiftkey : shiftID;
                return shiftID;
            }
            else
                return newGaurdkey;
        }





        private bool isDayShift(string shiftID)
        {
            bool blIsNightshift = false;

            if (shiftID == "")
                return false;

            DataTable dtShiftInfo_local =
                this.getDataFromDB.getGS_SHIFTInfo(null, "", shiftID,
                    "", "", false, false, "AND");

            if (!this.getDataFromDB.checkIfTableContainesData(dtShiftInfo_local))
                return false;

            DateTime shiftStartHour =
                DateTime.Parse(dtShiftInfo_local.Rows[0]["STARTTIME"].ToString());

            DateTime shiftEndHour =
                DateTime.Parse(dtShiftInfo_local.Rows[0]["ENDTIME"].ToString());

            DateTime shiftFirstMidHour =
                shiftStartHour.AddHours(((shiftEndHour - shiftStartHour).Hours / 4));

            DateTime shiftMidHour =
                shiftStartHour.AddHours(((shiftEndHour - shiftStartHour).Hours / 2));

            DateTime shiftLastMidHour =
                shiftEndHour.AddHours(((shiftEndHour - shiftStartHour).Hours / 4) * -1);

            DateTime dayShiftBegging = DateTime.Parse("12-23-2014 06:00:00");
            DateTime dayShiftEnding = DateTime.Parse("12-23-2014 19:00:00");

            int shiftStartAfterOnTime = 0;
            int shiftFirstMidHrOk = 0;
            int shiftMidHrOK = 0;
            int shiftLastMidHrOK = 0;
            int shiftEndsOnTime = 0;

            if (
                 dayShiftBegging.TimeOfDay.CompareTo(shiftStartHour.TimeOfDay) != 1
                 &&
                 dayShiftEnding.TimeOfDay.CompareTo(shiftEndHour.TimeOfDay) != -1
                 &&
                 dayShiftBegging.TimeOfDay.CompareTo(shiftFirstMidHour.TimeOfDay) == -1
                 &&
                 dayShiftEnding.TimeOfDay.CompareTo(shiftFirstMidHour.TimeOfDay) == 1
                )
                blIsNightshift = true;

            return blIsNightshift;

        }

        private bool isNightShift(string shiftID)
        {
            bool blIsNightshift = false;

            if (shiftID == "")
                return false;

            dataBuilder getDataFromDB = new dataBuilder();

            DataTable dtShiftInfo_local =
                getDataFromDB.getGS_SHIFTInfo(null, "", shiftID,
                    "", "", false, false, "AND");

            if (!getDataFromDB.checkIfTableContainesData(dtShiftInfo_local))
                return false;

            DateTime shiftStartHour =
                DateTime.Parse(dtShiftInfo_local.Rows[0]["STARTTIME"].ToString());

            DateTime shiftEndHour =
                DateTime.Parse(dtShiftInfo_local.Rows[0]["ENDTIME"].ToString());

            DateTime nightShiftBegging = DateTime.Parse("12-23-2014 17:30:00");
            DateTime nightShiftEnding = DateTime.Parse("12-23-2014 07:00:00");

            if (
                  (nightShiftBegging.TimeOfDay.CompareTo(shiftStartHour.TimeOfDay) != 1 ||
                   nightShiftEnding.TimeOfDay.CompareTo(shiftStartHour.TimeOfDay) == 1)
                &&
                  (nightShiftBegging.TimeOfDay.CompareTo(shiftEndHour.TimeOfDay) == -1 ||
                   nightShiftEnding.TimeOfDay.CompareTo(shiftEndHour.TimeOfDay) != -1)
                )
                blIsNightshift = true;

            return blIsNightshift;

        }


        private bool isGaurdAvailableForDuty(DateTime dutyDate, string postID,
            string shiftID, string gaurdID)
        {
            bool blGaurdIsAvailable = true;

            if (gaurdID == "104")
                blGaurdIsAvailable = true;

            if (this.isDutyReptitionInCycle(postID, shiftID, gaurdID))
                return false;

            string lastInCycleShiftOfGaurd =
                this.getPreviousInCycleShift(gaurdID, dutyDate);

            string lastOFFCycleShiftOfGaurd =
                this.getPreviousOffCycleShift(gaurdID, dutyDate);

            string lastShiftOfGaurd =
                this.getPreviousShift(gaurdID, dutyDate);


            string inCycleDayBeforShiftOfGaurd =
                this.getTheNthPreviousInCycleShift(gaurdID, dutyDate, 1);

            // Gaurds Which Where OFF Duty the Previous Day In A given Cycle...
            // ...Can not Attend Night Shift the Next Day.
            //if (lastInCycleShiftOfGaurd == offDutyShiftkey && 
            //    this.isNightShift(shiftID))
            //    return false;

            // Gaurds Which Where OFF Duty the Previous Day ...
            // ...Can not Attend Night Shift the Next Day.
            if (lastShiftOfGaurd == offDutyShiftkey &&
                this.isNightShift(shiftID))
                return false;

            // Gaurds Which Attend Night Shift The Previous Day Should Be Day OFF the Next Day.
            if (lastShiftOfGaurd != offDutyShiftkey &&
                lastShiftOfGaurd != newGaurdkey &&
                this.isNightShift(lastShiftOfGaurd))
                return false;

            // No Gaurds Should Attend Three Consequtive Day Shifts In The Same Cycle
            //if (inCycleDayBeforShiftOfGaurd != offDutyShiftkey &&
            //    inCycleDayBeforShiftOfGaurd != newGaurdkey &&
            //    lastInCycleShiftOfGaurd != offDutyShiftkey &&
            //    lastInCycleShiftOfGaurd != newGaurdkey &&
            //    this.isDayShift(lastInCycleShiftOfGaurd) &&
            //    this.isDayShift(inCycleDayBeforShiftOfGaurd) &&
            //    this.isDayShift(shiftID))
            //    return false;

            // No Gaurd Should take A day OFF every Two Days
            //    if (this.isNightShift(shiftID))
            //    {
            //        string theShiftBeforefourDays
            //            = this.getTheNthPreviousShift(gaurdID, dutyDate, 4);
            //        if (theShiftBeforefourDays == offDutyShiftkey)
            //            return false;
            //    }


            //DateTime midCycle = this.tm_CurrentCycleBeggingDate.AddDays(cycleMidWay);
            //if (midCycle.Date.CompareTo(dutyDate.Date) != 1)
            //{
            //    // No Gaurd Should take A day OFF every Two Days
            //    if (this.isNightShift(shiftID))
            //    {
            //        string theShiftBeforefourDays
            //            = this.getTheNthPreviousShift(gaurdID, dutyDate, 4);
            //        if (theShiftBeforefourDays == offDutyShiftkey)
            //            return false;
            //    }
            //}


            return blGaurdIsAvailable;
        }


        private int getGaurdPreferenceIdex(DateTime dutyDate, string postID,
            string shiftID, string gaurdID)
        {
            int PR_INDEX = 0;

            DataTable dtGaurdsPrvDutyInfo_local = new DataTable();

            for (int prvDutyCount = 0; prvDutyCount < this.intOFFCycleDutiesToConsider; prvDutyCount++)
            {
                dtGaurdsPrvDutyInfo_local =
                    this.getThe_Nth_PreviousDuty(gaurdID, dutyDate, prvDutyCount, false, true, true);
                if (!this.getDataFromDB.checkIfTableContainesData(dtGaurdsPrvDutyInfo_local))
                    break;

                if (dtGaurdsPrvDutyInfo_local.Rows[0]["GS_POST_ID"].ToString() != postID)
                    PR_INDEX++;

                if (dtGaurdsPrvDutyInfo_local.Rows[0]["GS_SHIFT_ID"].ToString() != shiftID)
                    PR_INDEX++;
            }

            return PR_INDEX;
        }


        private void createGaurdAvailabiltySheet()
        {

            this.dtDailyGardAvailbitlySheet.Rows.Clear();
            string postID = "";
            string shiftID = "";

            DateTime dutyShtDate = DateTime.Now;

            for (int dutyShtRC = 0; dutyShtRC <= this.dtNewDuty.Rows.Count - 1; dutyShtRC++)
            {
                dutyShtDate =
                    DateTime.Parse(this.dtNewDuty.Rows[dutyShtRC]["DUTYDATE"].ToString());
                if (dutyShtDate.Date.CompareTo(this.tm_CurrentProcessingDate.Date) != 0)
                    continue;

                postID =
                    this.dtNewDuty.Rows[dutyShtRC]["GS_POST_ID"].ToString();
                shiftID =
                    this.dtNewDuty.Rows[dutyShtRC]["GS_SHIFT_ID"].ToString();

                DataRow drNewGardAvailbitly = this.dtDailyGardAvailbitlySheet.NewRow();
                drNewGardAvailbitly["GS_POST_ID"] = postID;
                drNewGardAvailbitly["GS_SHIFT_ID"] = shiftID;
                drNewGardAvailbitly["GAURDCOUNT"] = 0;
                drNewGardAvailbitly["ISASSIGNED"] = "N";
                this.dtDailyGardAvailbitlySheet.Rows.Add(drNewGardAvailbitly);
            }
        }

        private void createDutyAvailabiltySheet()
        {
            this.dtDailyDutyAvailbitlySheet.Rows.Clear();
            string gaurdID = "";

            for (int gardRC = 0; gardRC <= this.dtAllActiveGaurds.Rows.Count - 1; gardRC++)
            {
                gaurdID =
                    this.dtAllActiveGaurds.Rows[gardRC]["GS_GAURD_ID"].ToString();

                DataRow drNewDutyAvailbitly = this.dtDailyDutyAvailbitlySheet.NewRow();
                drNewDutyAvailbitly["GS_GAURD_ID"] = gaurdID;
                drNewDutyAvailbitly["DUTYCOUNT"] = 0;
                drNewDutyAvailbitly["ISASSIGNED"] = "N";
                this.dtDailyDutyAvailbitlySheet.Rows.Add(drNewDutyAvailbitly);
            }
        }

        private void createAvailabiltySheets()
        {
            string postID = "";
            string shiftID = "";
            string gaurdID = "";

            bool blGardFound = false;
            bool blDutyFound = false;

            //Reset count of Both Sheets To ZERO
            for (int gardAVLBShtRC = 0;
                    gardAVLBShtRC <= this.dtDailyGardAvailbitlySheet.Rows.Count - 1; gardAVLBShtRC++)
            {
                this.dtDailyGardAvailbitlySheet.Rows[gardAVLBShtRC]["GAURDCOUNT"] = 0;
            }

            for (int dutyAVLBShtRC = 0;
                    dutyAVLBShtRC <= this.dtDailyDutyAvailbitlySheet.Rows.Count - 1; dutyAVLBShtRC++)
            {
                this.dtDailyDutyAvailbitlySheet.Rows[dutyAVLBShtRC]["DUTYCOUNT"] = 0;
            }

            //CREATE Count In Both Sheets
            for (int assgnmShtRC = 0;
                assgnmShtRC <= this.dtDailyDutyPossibiltySheet.Rows.Count - 1;
                assgnmShtRC++)
            {
                if (int.Parse(this.dtDailyDutyPossibiltySheet.Rows[assgnmShtRC]["AV_INDEX"].ToString()) != 1)
                    continue;
                blGardFound = false;
                blDutyFound = false;

                postID =
                    this.dtDailyDutyPossibiltySheet.Rows[assgnmShtRC]["GS_POST_ID"].ToString();
                shiftID =
                    this.dtDailyDutyPossibiltySheet.Rows[assgnmShtRC]["GS_SHIFT_ID"].ToString();
                gaurdID =
                    this.dtDailyDutyPossibiltySheet.Rows[assgnmShtRC]["GS_GAURD_ID"].ToString();

                for (int gardAVLBShtRC = 0;
                    gardAVLBShtRC <= this.dtDailyGardAvailbitlySheet.Rows.Count - 1; gardAVLBShtRC++)
                {
                    if (this.dtDailyGardAvailbitlySheet.Rows[gardAVLBShtRC]["GS_POST_ID"].ToString() == postID &&
                        this.dtDailyGardAvailbitlySheet.Rows[gardAVLBShtRC]["GS_SHIFT_ID"].ToString() == shiftID)
                    {
                        blDutyFound = true;
                        if (this.dtDailyGardAvailbitlySheet.Rows[gardAVLBShtRC]["ISASSIGNED"].ToString() == "N")
                        {
                            this.dtDailyGardAvailbitlySheet.Rows[gardAVLBShtRC]["GAURDCOUNT"] =
                            int.Parse(
                                this.dtDailyGardAvailbitlySheet.Rows[gardAVLBShtRC]["GAURDCOUNT"].ToString()
                                ) + 1;
                        }
                        break;
                    }
                }

                for (int dutyAVLBShtRC = 0;
                    dutyAVLBShtRC <= this.dtDailyDutyAvailbitlySheet.Rows.Count - 1; dutyAVLBShtRC++)
                {
                    if (this.dtDailyDutyAvailbitlySheet.Rows[dutyAVLBShtRC]["GS_GAURD_ID"].ToString() == gaurdID)
                    {
                        blGardFound = true;
                        if (this.dtDailyDutyAvailbitlySheet.Rows[dutyAVLBShtRC]["ISASSIGNED"].ToString() == "N")
                        {
                            this.dtDailyDutyAvailbitlySheet.Rows[dutyAVLBShtRC]["DUTYCOUNT"] =
                                int.Parse(
                                            this.dtDailyDutyAvailbitlySheet.Rows[dutyAVLBShtRC]["DUTYCOUNT"].ToString()
                                          ) + 1;
                        }
                        break;
                    }
                }

                if (!blDutyFound)
                {
                    DataRow drNewGardAvailbitly = this.dtDailyGardAvailbitlySheet.NewRow();
                    drNewGardAvailbitly["GS_POST_ID"] = postID;
                    drNewGardAvailbitly["GS_SHIFT_ID"] = shiftID;
                    drNewGardAvailbitly["GAURDCOUNT"] = 1;
                    drNewGardAvailbitly["ISASSIGNED"] = "N";
                    this.dtDailyGardAvailbitlySheet.Rows.Add(drNewGardAvailbitly);
                }

                if (!blGardFound)
                {
                    DataRow drNewDutyAvailbitly = this.dtDailyDutyAvailbitlySheet.NewRow();
                    drNewDutyAvailbitly["GS_GAURD_ID"] = gaurdID;
                    drNewDutyAvailbitly["DUTYCOUNT"] = 1;
                    drNewDutyAvailbitly["ISASSIGNED"] = "N";
                    this.dtDailyDutyAvailbitlySheet.Rows.Add(drNewDutyAvailbitly);
                }
            }
        }


        private int getMinimumPossibleNumberOfGaurds()
        {
            int minimumNumberOfGaurds =
                this.dtAllActiveGaurds.Rows.Count + 100;
            int currentDutyGaurdCount = 0;


            for (int gardAVLBShtRC = 0;
                    gardAVLBShtRC <= this.dtDailyGardAvailbitlySheet.Rows.Count - 1; gardAVLBShtRC++)
            {
                if (this.dtDailyGardAvailbitlySheet.Rows[gardAVLBShtRC]["ISASSIGNED"].ToString() == "Y")
                    continue;

                currentDutyGaurdCount =
                    int.Parse(this.dtDailyGardAvailbitlySheet.Rows[gardAVLBShtRC]["GAURDCOUNT"].ToString());

                if (currentDutyGaurdCount == 0)
                    continue;

                if (minimumNumberOfGaurds > currentDutyGaurdCount)
                    minimumNumberOfGaurds = currentDutyGaurdCount;
            }

            if (minimumNumberOfGaurds == this.dtAllActiveGaurds.Rows.Count + 100)
                minimumNumberOfGaurds = 0;

            return minimumNumberOfGaurds;
        }

        private int getMinimumPossibleNumberOfDuties()
        {
            int minimumNumberOfDuties =
                this.dtNewDuty.Rows.Count + 100;
            int currentGaurdDutyCount = 0;

            for (int dutyAVLBShtRC = 0;
                    dutyAVLBShtRC <= this.dtDailyDutyAvailbitlySheet.Rows.Count - 1; dutyAVLBShtRC++)
            {
                if (this.dtDailyDutyAvailbitlySheet.Rows[dutyAVLBShtRC]["ISASSIGNED"].ToString() == "Y")
                    continue;

                currentGaurdDutyCount =
                    int.Parse(this.dtDailyDutyAvailbitlySheet.Rows[dutyAVLBShtRC]["DUTYCOUNT"].ToString());

                if (currentGaurdDutyCount == 0)
                    continue;

                if (minimumNumberOfDuties > currentGaurdDutyCount)
                    minimumNumberOfDuties = currentGaurdDutyCount;
            }

            if (minimumNumberOfDuties == this.dtNewDuty.Rows.Count + 100)
                minimumNumberOfDuties = 0;

            return minimumNumberOfDuties;
        }


        private DataTable getAllGaurdsWithMinimumPossibleDutiesAvailable()
        {
            int minimumDutyCount =
                this.getMinimumPossibleNumberOfDuties();

            int dutyCount = -1;

            DataTable dtGaurdsWithMinimumPossibleDuty_local = new DataTable();
            dtGaurdsWithMinimumPossibleDuty_local.Columns.Add("GS_GAURD_ID");//,Type.GetType("System.Int16"));
            dtGaurdsWithMinimumPossibleDuty_local.Columns.Add("DUTYCOUNT");//, Type.GetType("System.Int16"));

            for (int dutyAVLBShtRC = 0;
                    dutyAVLBShtRC <= this.dtDailyDutyAvailbitlySheet.Rows.Count - 1; dutyAVLBShtRC++)
            {
                dutyCount =
                    int.Parse(this.dtDailyDutyAvailbitlySheet.Rows[dutyAVLBShtRC]["DUTYCOUNT"].ToString());

                if (dutyCount == minimumDutyCount)
                {
                    DataRow drNewMinDutyGaurd = dtGaurdsWithMinimumPossibleDuty_local.NewRow();

                    drNewMinDutyGaurd["GS_GAURD_ID"] =
                        this.dtDailyDutyAvailbitlySheet.Rows[dutyAVLBShtRC]["GS_GAURD_ID"].ToString();
                    drNewMinDutyGaurd["DUTYCOUNT"] =
                        this.dtDailyDutyAvailbitlySheet.Rows[dutyAVLBShtRC]["DUTYCOUNT"].ToString();

                    dtGaurdsWithMinimumPossibleDuty_local.Rows.Add(drNewMinDutyGaurd);
                }
            }
            return dtGaurdsWithMinimumPossibleDuty_local;
        }

        private DataTable getAllDutiesWithMinimumPossibleGaurdsAvailable()
        {
            int minimumGaurdCount =
                this.getMinimumPossibleNumberOfGaurds();

            int gaurdCount = -1;

            DataTable dtDutiesWithMinimumPossibleGaurd_local = new DataTable();
            dtDutiesWithMinimumPossibleGaurd_local.Columns.Add("GS_POST_ID");//, Type.GetType("System.Int16"));
            dtDutiesWithMinimumPossibleGaurd_local.Columns.Add("GS_SHIFT_ID");//, Type.GetType("System.Int16"));
            dtDutiesWithMinimumPossibleGaurd_local.Columns.Add("GAURDCOUNT");//, Type.GetType("System.Int16"));

            for (int gardAVLBShtRC = 0;
                    gardAVLBShtRC <= this.dtDailyGardAvailbitlySheet.Rows.Count - 1; gardAVLBShtRC++)
            {
                gaurdCount =
                    int.Parse(this.dtDailyGardAvailbitlySheet.Rows[gardAVLBShtRC]["GAURDCOUNT"].ToString());

                if (gaurdCount == minimumGaurdCount)
                {
                    DataRow drNewMinGaurdDuty = dtDutiesWithMinimumPossibleGaurd_local.NewRow();

                    drNewMinGaurdDuty["GS_POST_ID"] =
                        this.dtDailyGardAvailbitlySheet.Rows[gardAVLBShtRC]["GS_POST_ID"].ToString();
                    drNewMinGaurdDuty["GS_SHIFT_ID"] =
                        this.dtDailyGardAvailbitlySheet.Rows[gardAVLBShtRC]["GS_SHIFT_ID"].ToString();
                    drNewMinGaurdDuty["GAURDCOUNT"] =
                        this.dtDailyGardAvailbitlySheet.Rows[gardAVLBShtRC]["GAURDCOUNT"].ToString();

                    dtDutiesWithMinimumPossibleGaurd_local.Rows.Add(drNewMinGaurdDuty);
                }
            }
            return dtDutiesWithMinimumPossibleGaurd_local;
        }


        private DataTable getPreferedDutyForGaurd(DateTime dutyDate, string gaurdID)
        {
            int maxGaurdPR_Idex = 0;
            int assgnmShtPR_Index = -1;

            for (int assgnmShtRC = 0;
                assgnmShtRC <= this.dtDailyDutyPossibiltySheet.Rows.Count - 1;
                assgnmShtRC++)
            {
                if (this.dtDailyDutyPossibiltySheet.Rows[assgnmShtRC]["GS_GAURD_ID"].ToString() != gaurdID)
                    continue;

                if (this.dtDailyDutyPossibiltySheet.Rows[assgnmShtRC]["AV_INDEX"].ToString() == "0" ||
                    this.dtDailyDutyPossibiltySheet.Rows[assgnmShtRC]["ISONDUTY"].ToString() == "Y")
                    continue;

                assgnmShtPR_Index =
                    int.Parse(this.dtDailyDutyPossibiltySheet.Rows[assgnmShtRC]["PR_INDEX"].ToString());

                if (assgnmShtPR_Index > maxGaurdPR_Idex)
                    maxGaurdPR_Idex = assgnmShtPR_Index;
            }

            DataTable dtPreferredDuties_local = new DataTable();
            dtPreferredDuties_local.Columns.Add("DUTYDATE");//, Type.GetType("System.DateTime"));
            dtPreferredDuties_local.Columns.Add("GS_GAURD_ID");//, Type.GetType("System.Int32"));
            dtPreferredDuties_local.Columns.Add("GS_POST_ID");//, Type.GetType("System.Int32"));
            dtPreferredDuties_local.Columns.Add("GS_SHIFT_ID");//, Type.GetType("System.Int32"));            
            dtPreferredDuties_local.Columns.Add("PR_INDEX");//, Type.GetType("System.Int32"));
            dtPreferredDuties_local.Columns.Add("DRAWINGS", Type.GetType("System.Int32"));

            for (int assgnmShtRC = 0;
                assgnmShtRC <= this.dtDailyDutyPossibiltySheet.Rows.Count - 1;
                assgnmShtRC++)
            {
                if (this.dtDailyDutyPossibiltySheet.Rows[assgnmShtRC]["GS_GAURD_ID"].ToString() != gaurdID)
                    continue;

                if (this.dtDailyDutyPossibiltySheet.Rows[assgnmShtRC]["AV_INDEX"].ToString() == "0" ||
                    this.dtDailyDutyPossibiltySheet.Rows[assgnmShtRC]["ISONDUTY"].ToString() == "Y")
                    continue;

                if (maxGaurdPR_Idex !=
                    int.Parse(this.dtDailyDutyPossibiltySheet.Rows[assgnmShtRC]["PR_INDEX"].ToString()))
                    continue;

                DataRow drNewPreferredDuties = dtPreferredDuties_local.NewRow();
                drNewPreferredDuties["DUTYDATE"] =
                    this.dtDailyDutyPossibiltySheet.Rows[assgnmShtRC]["DUTYDATE"].ToString();
                drNewPreferredDuties["GS_GAURD_ID"] =
                    this.dtDailyDutyPossibiltySheet.Rows[assgnmShtRC]["GS_GAURD_ID"].ToString();
                drNewPreferredDuties["GS_POST_ID"] =
                    this.dtDailyDutyPossibiltySheet.Rows[assgnmShtRC]["GS_POST_ID"].ToString();
                drNewPreferredDuties["GS_SHIFT_ID"] =
                    this.dtDailyDutyPossibiltySheet.Rows[assgnmShtRC]["GS_SHIFT_ID"].ToString();
                drNewPreferredDuties["PR_INDEX"] =
                    this.dtDailyDutyPossibiltySheet.Rows[assgnmShtRC]["PR_INDEX"].ToString();
                drNewPreferredDuties["DRAWINGS"] = 0;

                dtPreferredDuties_local.Rows.Add(drNewPreferredDuties);
            }

            if (dtPreferredDuties_local.Rows.Count > 1)
            {
                int selectedRow =
                    this.getRandomNumber(0, dtPreferredDuties_local.Rows.Count);

                dtPreferredDuties_local.Rows[selectedRow]["DRAWINGS"] = 1;
                for (int rowCounter = dtPreferredDuties_local.Rows.Count - 1; rowCounter >= 0; rowCounter--)
                    if (dtPreferredDuties_local.Rows[selectedRow]["DRAWINGS"].ToString() != "1")
                        dtPreferredDuties_local.Rows.RemoveAt(rowCounter);
            }

            dtPreferredDuties_local.Columns.RemoveAt(
                dtPreferredDuties_local.Columns.IndexOf("DRAWINGS"));

            return dtPreferredDuties_local;
        }

        private DataTable getPreferedGaurdForDuty(DateTime dutyDate, string postID,
            string shiftID)
        {
            int maxDutyPR_Idex = 0;
            int assgnmShtPR_Index = -1;

            for (int assgnmShtRC = 0;
                assgnmShtRC <= this.dtDailyDutyPossibiltySheet.Rows.Count - 1;
                assgnmShtRC++)
            {
                if (this.dtDailyDutyPossibiltySheet.Rows[assgnmShtRC]["GS_POST_ID"].ToString() != postID ||
                    this.dtDailyDutyPossibiltySheet.Rows[assgnmShtRC]["GS_SHIFT_ID"].ToString() != shiftID)
                    continue;

                if (this.dtDailyDutyPossibiltySheet.Rows[assgnmShtRC]["AV_INDEX"].ToString() == "0" ||
                    this.dtDailyDutyPossibiltySheet.Rows[assgnmShtRC]["ISONDUTY"].ToString() == "Y")
                    continue;

                assgnmShtPR_Index =
                    int.Parse(this.dtDailyDutyPossibiltySheet.Rows[assgnmShtRC]["PR_INDEX"].ToString());

                if (assgnmShtPR_Index > maxDutyPR_Idex)
                    maxDutyPR_Idex = assgnmShtPR_Index;
            }

            DataTable dtpreferredGaurds_local = new DataTable();
            dtpreferredGaurds_local.Columns.Add("DUTYDATE");//, Type.GetType("System.DateTime"));
            dtpreferredGaurds_local.Columns.Add("GS_GAURD_ID");//, Type.GetType("System.Int32"));
            dtpreferredGaurds_local.Columns.Add("GS_POST_ID");//, Type.GetType("System.Int32"));
            dtpreferredGaurds_local.Columns.Add("GS_SHIFT_ID");//, Type.GetType("System.Int32"));            
            dtpreferredGaurds_local.Columns.Add("PR_INDEX");//, Type.GetType("System.Int32"));
            dtpreferredGaurds_local.Columns.Add("DRAWINGS", Type.GetType("System.Int32"));

            for (int assgnmShtRC = 0;
                assgnmShtRC <= this.dtDailyDutyPossibiltySheet.Rows.Count - 1;
                assgnmShtRC++)
            {
                if (this.dtDailyDutyPossibiltySheet.Rows[assgnmShtRC]["GS_POST_ID"].ToString() != postID ||
                    this.dtDailyDutyPossibiltySheet.Rows[assgnmShtRC]["GS_SHIFT_ID"].ToString() != shiftID)
                    continue;

                if (this.dtDailyDutyPossibiltySheet.Rows[assgnmShtRC]["AV_INDEX"].ToString() == "0" ||
                    this.dtDailyDutyPossibiltySheet.Rows[assgnmShtRC]["ISONDUTY"].ToString() == "Y")
                    continue;

                if (maxDutyPR_Idex !=
                    int.Parse(this.dtDailyDutyPossibiltySheet.Rows[assgnmShtRC]["PR_INDEX"].ToString()))
                    continue;

                DataRow drPreferredGaurds = dtpreferredGaurds_local.NewRow();
                drPreferredGaurds["DUTYDATE"] =
                    this.dtDailyDutyPossibiltySheet.Rows[assgnmShtRC]["DUTYDATE"].ToString();
                drPreferredGaurds["GS_GAURD_ID"] =
                    this.dtDailyDutyPossibiltySheet.Rows[assgnmShtRC]["GS_GAURD_ID"].ToString();
                drPreferredGaurds["GS_POST_ID"] =
                    this.dtDailyDutyPossibiltySheet.Rows[assgnmShtRC]["GS_POST_ID"].ToString();
                drPreferredGaurds["GS_SHIFT_ID"] =
                    this.dtDailyDutyPossibiltySheet.Rows[assgnmShtRC]["GS_SHIFT_ID"].ToString();
                drPreferredGaurds["PR_INDEX"] =
                    this.dtDailyDutyPossibiltySheet.Rows[assgnmShtRC]["PR_INDEX"].ToString();
                drPreferredGaurds["DRAWINGS"] = 0;

                dtpreferredGaurds_local.Rows.Add(drPreferredGaurds);
            }

            if (dtpreferredGaurds_local.Rows.Count > 1)
            {
                int selectedRow =
                    this.getRandomNumber(0, dtpreferredGaurds_local.Rows.Count);

                dtpreferredGaurds_local.Rows[selectedRow]["DRAWINGS"] = 1;
                for (int rowCounter = dtpreferredGaurds_local.Rows.Count - 1; rowCounter >= 0; rowCounter--)
                    if (dtpreferredGaurds_local.Rows[selectedRow]["DRAWINGS"].ToString() != "1")
                        dtpreferredGaurds_local.Rows.RemoveAt(rowCounter);
            }

            dtpreferredGaurds_local.Columns.RemoveAt(
                dtpreferredGaurds_local.Columns.IndexOf("DRAWINGS"));

            return dtpreferredGaurds_local;
        }


        private void creatAssignment(DateTime dutyDate, string postID, string shiftID, string gaurdID)
        {
            DateTime dutyShtDate_local;

            string postID_local = "";
            string shiftID_local = "";

            //Create off Duty Gaurds If provided

            if (postID == "" || shiftID == "")
            {
                this.addNewDutyRow(dutyDate, "", "", gaurdID);
                return;
            }

            //Assign Gaurd to Duty in New Duty Sheet
            for (int dutyShtRC = 0; dutyShtRC <= this.dtNewDuty.Rows.Count - 1; dutyShtRC++)
            {
                dutyShtDate_local =
                    DateTime.Parse(this.dtNewDuty.Rows[dutyShtRC]["DUTYDATE"].ToString());

                if (dutyShtDate_local.Date.CompareTo(dutyDate.Date) != 0)
                    continue;

                postID_local =
                    this.dtNewDuty.Rows[dutyShtRC]["GS_POST_ID"].ToString();
                shiftID_local =
                    this.dtNewDuty.Rows[dutyShtRC]["GS_SHIFT_ID"].ToString();

                if (postID_local != postID ||
                    shiftID_local != shiftID)
                    continue;

                if (gaurdID == "")
                {
                    this.dtNewDuty.Rows[dutyShtRC]["ISACTIVE"] = "Y";
                    this.dtNewDuty.Rows[dutyShtRC]["ISONDUTY"] = "N";
                    return;
                }
                else
                {
                    this.dtNewDuty.Rows[dutyShtRC]["GS_GAURD_ID"] = gaurdID;
                    this.dtNewDuty.Rows[dutyShtRC]["ISACTIVE"] = "Y";
                    this.dtNewDuty.Rows[dutyShtRC]["ISONDUTY"] = "Y";
                    break;
                }
            }

            this.updateDailyAssignmentPossiblilitySheet(dutyDate, postID, shiftID, gaurdID);
        }

        private void updateDailyAssignmentPossiblilitySheet(DateTime dutyDate, string postID, string shiftID, string gaurdID)
        {
            DateTime dutyShtDate_local;

            string postID_local = "";
            string shiftID_local = "";

            string gardID_local = "";

            //Update Daily Assignment Sheet

            for (int dutyShtRC = 0; dutyShtRC <= this.dtDailyDutyPossibiltySheet.Rows.Count - 1; dutyShtRC++)
            {
                dutyShtDate_local =
                    DateTime.Parse(this.dtDailyDutyPossibiltySheet.Rows[dutyShtRC]["DUTYDATE"].ToString());

                if (dutyShtDate_local.Date.CompareTo(dutyDate.Date) != 0)
                    continue;

                postID_local =
                    this.dtDailyDutyPossibiltySheet.Rows[dutyShtRC]["GS_POST_ID"].ToString();
                shiftID_local =
                    this.dtDailyDutyPossibiltySheet.Rows[dutyShtRC]["GS_SHIFT_ID"].ToString();
                gardID_local =
                    this.dtDailyDutyPossibiltySheet.Rows[dutyShtRC]["GS_GAURD_ID"].ToString();

                if (gardID_local == gaurdID ||
                    (postID_local == postID &&
                    shiftID_local == shiftID)
                    )
                {
                    this.dtDailyDutyPossibiltySheet.Rows[dutyShtRC]["AV_INDEX"] = 0;
                    this.dtDailyDutyPossibiltySheet.Rows[dutyShtRC]["PR_INDEX"] = 0;
                    this.dtDailyDutyPossibiltySheet.Rows[dutyShtRC]["ISACTIVE"] = "Y";
                    this.dtDailyDutyPossibiltySheet.Rows[dutyShtRC]["ISONDUTY"] = "Y";
                }
            }

            this.updateAvailabilitySheets(dutyDate, postID, shiftID, gaurdID);

        }

        private void updateAvailabilitySheets(DateTime dutyDate, string postID, string shiftID, string gaurdID)
        {
            this.createAvailabiltySheets();

            for (int gardAVLBShtRC = 0;
                    gardAVLBShtRC <= this.dtDailyGardAvailbitlySheet.Rows.Count - 1; gardAVLBShtRC++)
            {
                if (this.dtDailyGardAvailbitlySheet.Rows[gardAVLBShtRC]["GS_POST_ID"].ToString() == postID &&
                    this.dtDailyGardAvailbitlySheet.Rows[gardAVLBShtRC]["GS_SHIFT_ID"].ToString() == shiftID)
                {
                    this.dtDailyGardAvailbitlySheet.Rows[gardAVLBShtRC]["ISASSIGNED"] = "Y";
                    this.dtDailyGardAvailbitlySheet.Rows[gardAVLBShtRC]["GAURDCOUNT"] = 0;
                    break;
                }
            }

            for (int dutyAVLBShtRC = 0;
                    dutyAVLBShtRC <= this.dtDailyDutyAvailbitlySheet.Rows.Count - 1; dutyAVLBShtRC++)
            {
                if (this.dtDailyDutyAvailbitlySheet.Rows[dutyAVLBShtRC]["GS_GAURD_ID"].ToString() == gaurdID)
                {
                    this.dtDailyDutyAvailbitlySheet.Rows[dutyAVLBShtRC]["ISASSIGNED"] = "Y";
                    this.dtDailyDutyAvailbitlySheet.Rows[dutyAVLBShtRC]["DUTYCOUNT"] = 0;
                    break;
                }
            }
            return;
        }


        private void selectGaurdDutyCombination()
        {
            int minimumGaurdAvailable =
                this.getMinimumPossibleNumberOfGaurds();
            int minimumDutiesAvailable =
                this.getMinimumPossibleNumberOfDuties();

            while (minimumGaurdAvailable > 0 && minimumDutiesAvailable > 0)
            {
                if (minimumDutiesAvailable < minimumGaurdAvailable)
                {
                    this.assignGaurdsToMinimumDuty();
                }
                else if (minimumDutiesAvailable > minimumGaurdAvailable)
                {
                    this.assignDutiesToMinimumGaurds();
                }
                else if (minimumDutiesAvailable == minimumGaurdAvailable)
                {
                    this.assignDutiesToMinimumGaurds();
                }


                minimumGaurdAvailable =
                    this.getMinimumPossibleNumberOfGaurds();
                minimumDutiesAvailable =
                    this.getMinimumPossibleNumberOfDuties();
            };

            this.scavangeAssignment();
            this.recordOffDutyGaurds();
            this.recordOFFGaurdedDuties();
        }

        private void assignGaurdsToMinimumDuty()
        {
            int minimumDutiesAvailable =
               this.getMinimumPossibleNumberOfDuties();

            if (minimumDutiesAvailable <= 0)
                return;

            DataTable dtMinDutyGaurds_local =
                this.getAllGaurdsWithMinimumPossibleDutiesAvailable();

            dtMinDutyGaurds_local.Columns.Add("DUTYDATE");//, Type.GetType("System.DateTime"));            
            dtMinDutyGaurds_local.Columns.Add("GS_POST_ID");//, Type.GetType("System.Int32"));
            dtMinDutyGaurds_local.Columns.Add("GS_SHIFT_ID");//, Type.GetType("System.Int32"));            
            dtMinDutyGaurds_local.Columns.Add("PR_INDEX");//, Type.GetType("System.Int32"));
            dtMinDutyGaurds_local.Columns.Add("DRAWINGS", Type.GetType("System.Int32"));

            string minDutyGaurdsID = "";

            DataTable prferredDuty = new DataTable();


            for (int minDutyGaurdsRC = 0;
                minDutyGaurdsRC <= dtMinDutyGaurds_local.Rows.Count - 1; minDutyGaurdsRC++)
            {
                minDutyGaurdsID =
                    dtMinDutyGaurds_local.Rows[minDutyGaurdsRC]["GS_GAURD_ID"].ToString();

                prferredDuty =
                    this.getPreferedDutyForGaurd(this.tm_CurrentProcessingDate,
                                                 minDutyGaurdsID);
                if (!this.getDataFromDB.checkIfTableContainesData(prferredDuty))
                    continue;

                dtMinDutyGaurds_local.Rows[minDutyGaurdsRC]["DUTYDATE"] =
                    prferredDuty.Rows[0]["DUTYDATE"].ToString();
                dtMinDutyGaurds_local.Rows[minDutyGaurdsRC]["GS_POST_ID"] =
                    prferredDuty.Rows[0]["GS_POST_ID"].ToString();
                dtMinDutyGaurds_local.Rows[minDutyGaurdsRC]["GS_SHIFT_ID"] =
                    prferredDuty.Rows[0]["GS_SHIFT_ID"].ToString();
                dtMinDutyGaurds_local.Rows[minDutyGaurdsRC]["PR_INDEX"] =
                    prferredDuty.Rows[0]["PR_INDEX"].ToString();
                dtMinDutyGaurds_local.Rows[minDutyGaurdsRC]["DRAWINGS"] = 0;
            }

            string postID_1 = "";
            string shiftID_1 = "";
            int PR_Index_1 = -1;

            string postID_2 = "";
            string shiftID_2 = "";
            int PR_Index_2 = -1;


            for (int minDutyGaurdsRC = dtMinDutyGaurds_local.Rows.Count - 1; minDutyGaurdsRC >= 0; minDutyGaurdsRC--)
            {
                if (int.Parse(dtMinDutyGaurds_local.Rows[minDutyGaurdsRC]["DRAWINGS"].ToString()) == -1)
                    continue;

                dtMinDutyGaurds_local.Rows[minDutyGaurdsRC]["DRAWINGS"] = 1;

                postID_1 =
                    dtMinDutyGaurds_local.Rows[minDutyGaurdsRC]["GS_POST_ID"].ToString();
                shiftID_1 =
                    dtMinDutyGaurds_local.Rows[minDutyGaurdsRC]["GS_SHIFT_ID"].ToString();
                PR_Index_1 =
                    int.Parse(dtMinDutyGaurds_local.Rows[minDutyGaurdsRC]["PR_INDEX"].ToString());

                for (int minDutyGaurdsRC_2 = minDutyGaurdsRC - 1; minDutyGaurdsRC_2 >= 0; minDutyGaurdsRC_2--)
                {
                    if (int.Parse(dtMinDutyGaurds_local.Rows[minDutyGaurdsRC_2]["DRAWINGS"].ToString()) == -1)
                        continue;

                    postID_2 =
                        dtMinDutyGaurds_local.Rows[minDutyGaurdsRC_2]["GS_POST_ID"].ToString();
                    shiftID_2 =
                        dtMinDutyGaurds_local.Rows[minDutyGaurdsRC_2]["GS_SHIFT_ID"].ToString();
                    PR_Index_2 =
                        int.Parse(dtMinDutyGaurds_local.Rows[minDutyGaurdsRC_2]["PR_INDEX"].ToString());

                    if (postID_1 != postID_2 || shiftID_1 != shiftID_2)
                        continue;

                    if (PR_Index_2 > PR_Index_1)
                    {
                        dtMinDutyGaurds_local.Rows[minDutyGaurdsRC]["DRAWINGS"] = -1;
                        dtMinDutyGaurds_local.Rows[minDutyGaurdsRC_2]["DRAWINGS"] = 1;
                        break;
                    }
                    else if (PR_Index_2 < PR_Index_1)
                    {
                        dtMinDutyGaurds_local.Rows[minDutyGaurdsRC]["DRAWINGS"] = 1;
                        dtMinDutyGaurds_local.Rows[minDutyGaurdsRC_2]["DRAWINGS"] = -1;
                        continue;
                    }
                    else if (PR_Index_2 == PR_Index_1)
                    {
                        int selectedRow = this.getRandomNumber(0, 2);

                        if (selectedRow == 0)
                        {
                            dtMinDutyGaurds_local.Rows[minDutyGaurdsRC]["DRAWINGS"] = 1;
                            dtMinDutyGaurds_local.Rows[minDutyGaurdsRC_2]["DRAWINGS"] = -1;
                            continue;
                        }
                        else
                        {
                            dtMinDutyGaurds_local.Rows[minDutyGaurdsRC]["DRAWINGS"] = -1;
                            dtMinDutyGaurds_local.Rows[minDutyGaurdsRC_2]["DRAWINGS"] = 1;
                            break;
                        }
                    }
                }
            }

            string gaurdID = "";

            for (int minDutyGaurdsRC = 0;
                    minDutyGaurdsRC <= dtMinDutyGaurds_local.Rows.Count - 1;
                    minDutyGaurdsRC++)
            {
                if (int.Parse(dtMinDutyGaurds_local.Rows[minDutyGaurdsRC]["DRAWINGS"].ToString()) != 1)
                    continue;

                postID_1 =
                    dtMinDutyGaurds_local.Rows[minDutyGaurdsRC]["GS_POST_ID"].ToString();
                shiftID_1 =
                    dtMinDutyGaurds_local.Rows[minDutyGaurdsRC]["GS_SHIFT_ID"].ToString();
                PR_Index_1 =
                    int.Parse(dtMinDutyGaurds_local.Rows[minDutyGaurdsRC]["PR_INDEX"].ToString());

                gaurdID =
                    dtMinDutyGaurds_local.Rows[minDutyGaurdsRC]["GS_GAURD_ID"].ToString();

                //this.creatAssignment(this.tm_CurrentProcessingDate, postID_1, shiftID_1, gaurdID);
                //break;

                if (this.isMinimumValueAssignment(postID_1, shiftID_1, gaurdID))
                    this.creatAssignment(this.tm_CurrentProcessingDate, postID_1, shiftID_1, gaurdID);
                else
                    break;
                //this.writeToFile(postID_1 + "," + shiftID_1 + "," + gaurdID);
            }
        }

        private void assignDutiesToMinimumGaurds()
        {

            int minimumGaurdsAvailable =
               this.getMinimumPossibleNumberOfGaurds();

            if (minimumGaurdsAvailable <= 0)
                return;

            DataTable dtMinGaurdDuties_local =
                this.getAllDutiesWithMinimumPossibleGaurdsAvailable();

            dtMinGaurdDuties_local.Columns.Add("DUTYDATE");//, Type.GetType("System.DateTime"));            
            dtMinGaurdDuties_local.Columns.Add("GS_GAURD_ID");//, Type.GetType("System.Int32"));                        
            dtMinGaurdDuties_local.Columns.Add("PR_INDEX");//, Type.GetType("System.Int32"));
            dtMinGaurdDuties_local.Columns.Add("DRAWINGS", Type.GetType("System.Int32"));

            string minGaurdPostID = "";
            string minGaurdShiftID = "";

            DataTable prferredGaurd = new DataTable();


            for (int minGaurdDutiesRC = 0;
                minGaurdDutiesRC <= dtMinGaurdDuties_local.Rows.Count - 1; minGaurdDutiesRC++)
            {
                minGaurdPostID =
                    dtMinGaurdDuties_local.Rows[minGaurdDutiesRC]["GS_POST_ID"].ToString();
                minGaurdShiftID =
                    dtMinGaurdDuties_local.Rows[minGaurdDutiesRC]["GS_SHIFT_ID"].ToString();

                prferredGaurd =
                    this.getPreferedGaurdForDuty(this.tm_CurrentProcessingDate, minGaurdPostID, minGaurdShiftID);


                if (!this.getDataFromDB.checkIfTableContainesData(prferredGaurd))
                    continue;

                dtMinGaurdDuties_local.Rows[minGaurdDutiesRC]["DUTYDATE"] =
                    prferredGaurd.Rows[0]["DUTYDATE"].ToString();
                dtMinGaurdDuties_local.Rows[minGaurdDutiesRC]["GS_GAURD_ID"] =
                    prferredGaurd.Rows[0]["GS_GAURD_ID"].ToString();
                dtMinGaurdDuties_local.Rows[minGaurdDutiesRC]["PR_INDEX"] =
                    prferredGaurd.Rows[0]["PR_INDEX"].ToString();
                dtMinGaurdDuties_local.Rows[minGaurdDutiesRC]["DRAWINGS"] = 0;
            }

            string postID_1 = "";
            string shiftID_1 = "";
            int PR_Index_1 = -1;

            string postID_2 = "";
            string shiftID_2 = "";
            int PR_Index_2 = -1;


            for (int minGaurdDutiesRC = dtMinGaurdDuties_local.Rows.Count - 1; minGaurdDutiesRC >= 0; minGaurdDutiesRC--)
            {
                if (int.Parse(dtMinGaurdDuties_local.Rows[minGaurdDutiesRC]["DRAWINGS"].ToString()) == -1)
                    continue;

                dtMinGaurdDuties_local.Rows[minGaurdDutiesRC]["DRAWINGS"] = 1;

                postID_1 =
                    dtMinGaurdDuties_local.Rows[minGaurdDutiesRC]["GS_POST_ID"].ToString();
                shiftID_1 =
                    dtMinGaurdDuties_local.Rows[minGaurdDutiesRC]["GS_SHIFT_ID"].ToString();
                PR_Index_1 =
                    int.Parse(dtMinGaurdDuties_local.Rows[minGaurdDutiesRC]["PR_INDEX"].ToString());

                for (int minGaurdDutiesRC_2 = minGaurdDutiesRC - 1; minGaurdDutiesRC_2 >= 0; minGaurdDutiesRC_2--)
                {
                    if (int.Parse(dtMinGaurdDuties_local.Rows[minGaurdDutiesRC_2]["DRAWINGS"].ToString()) == -1)
                        continue;

                    postID_2 =
                        dtMinGaurdDuties_local.Rows[minGaurdDutiesRC_2]["GS_POST_ID"].ToString();
                    shiftID_2 =
                        dtMinGaurdDuties_local.Rows[minGaurdDutiesRC_2]["GS_SHIFT_ID"].ToString();
                    PR_Index_2 =
                        int.Parse(dtMinGaurdDuties_local.Rows[minGaurdDutiesRC_2]["PR_INDEX"].ToString());

                    if (postID_1 != postID_2 || shiftID_1 != shiftID_2)
                        continue;

                    if (PR_Index_2 > PR_Index_1)
                    {
                        dtMinGaurdDuties_local.Rows[minGaurdDutiesRC]["DRAWINGS"] = -1;
                        dtMinGaurdDuties_local.Rows[minGaurdDutiesRC_2]["DRAWINGS"] = 1;
                        break;
                    }
                    else if (PR_Index_2 < PR_Index_1)
                    {
                        dtMinGaurdDuties_local.Rows[minGaurdDutiesRC]["DRAWINGS"] = 1;
                        dtMinGaurdDuties_local.Rows[minGaurdDutiesRC_2]["DRAWINGS"] = -1;
                        continue;
                    }
                    else if (PR_Index_2 == PR_Index_1)
                    {
                        int selectedRow = this.getRandomNumber(0, 2);

                        if (selectedRow == 0)
                        {
                            dtMinGaurdDuties_local.Rows[minGaurdDutiesRC]["DRAWINGS"] = 1;
                            dtMinGaurdDuties_local.Rows[minGaurdDutiesRC_2]["DRAWINGS"] = -1;
                            continue;
                        }
                        else
                        {
                            dtMinGaurdDuties_local.Rows[minGaurdDutiesRC]["DRAWINGS"] = -1;
                            dtMinGaurdDuties_local.Rows[minGaurdDutiesRC_2]["DRAWINGS"] = 1;
                            break;
                        }
                    }
                }
            }


            string gaurdID = "";

            for (int minGaurdDutiesRC = 0;
                    minGaurdDutiesRC <= dtMinGaurdDuties_local.Rows.Count - 1;
                    minGaurdDutiesRC++)
            {
                if (int.Parse(dtMinGaurdDuties_local.Rows[minGaurdDutiesRC]["DRAWINGS"].ToString()) != 1)
                    continue;

                postID_1 =
                    dtMinGaurdDuties_local.Rows[minGaurdDutiesRC]["GS_POST_ID"].ToString();
                shiftID_1 =
                    dtMinGaurdDuties_local.Rows[minGaurdDutiesRC]["GS_SHIFT_ID"].ToString();
                PR_Index_1 =
                    int.Parse(dtMinGaurdDuties_local.Rows[minGaurdDutiesRC]["PR_INDEX"].ToString());

                gaurdID =
                    dtMinGaurdDuties_local.Rows[minGaurdDutiesRC]["GS_GAURD_ID"].ToString();

                //this.creatAssignment(this.tm_CurrentProcessingDate, postID_1, shiftID_1, gaurdID);
                //break;

                if (this.isMinimumValueAssignment(postID_1, shiftID_1, gaurdID))
                    this.creatAssignment(this.tm_CurrentProcessingDate, postID_1, shiftID_1, gaurdID);
                else
                    break;
                //this.writeToFile(postID_1 + "," + shiftID_1 + "," + gaurdID);
            }
        }

        private void recordOffDutyGaurds()
        {
            string gaurdID = "";
            DateTime tm_NewDutyDate_lcoal;

            for (int dutyAVLBShtRC = 0;
                    dutyAVLBShtRC <= this.dtDailyDutyAvailbitlySheet.Rows.Count - 1; dutyAVLBShtRC++)
            {
                if (this.dtDailyDutyAvailbitlySheet.Rows[dutyAVLBShtRC]["ISASSIGNED"].ToString() == "Y")
                    continue;

                if (int.Parse(this.dtDailyDutyAvailbitlySheet.Rows[dutyAVLBShtRC]["DUTYCOUNT"].ToString()) != 0)
                    continue;

                gaurdID =
                    this.dtDailyDutyAvailbitlySheet.Rows[dutyAVLBShtRC]["GS_GAURD_ID"].ToString();

                this.creatAssignment(this.tm_CurrentProcessingDate, "", "", gaurdID);

                for (int dutyRC = this.dtNewDuty.Rows.Count - 1; dutyRC >= 0; dutyRC--)
                {
                    if (this.dtNewDuty.Rows[dutyRC]["ISONDUTY"].ToString() != "")
                        continue;

                    tm_NewDutyDate_lcoal =
                        DateTime.Parse(this.dtNewDuty.Rows[dutyRC]["DUTYDATE"].ToString());

                    if (this.tm_CurrentProcessingDate.Date.CompareTo(tm_NewDutyDate_lcoal.Date) != 0)
                        continue;

                    if (this.dtNewDuty.Rows[dutyRC]["GS_POST_ID"].ToString() == "" &&
                        this.dtNewDuty.Rows[dutyRC]["GS_SHIFT_ID"].ToString() == "" &&
                        this.dtNewDuty.Rows[dutyRC]["GS_GAURD_ID"].ToString() == gaurdID)
                    {
                        this.dtNewDuty.Rows[dutyRC]["ISONDUTY"] = "N";
                        this.dtNewDuty.Rows[dutyRC]["ISACTIVE"] = "Y";
                        //this.writeToFile(",," + gaurdID);
                        break;
                    }
                }
            }

            return;
        }

        private void recordOFFGaurdedDuties()
        {
            string postID = "";
            string shiftID = "";
            DateTime tm_NewDutyDate_lcoal;

            for (int gardAVLBShtRC = 0;
                gardAVLBShtRC <= this.dtDailyGardAvailbitlySheet.Rows.Count - 1; gardAVLBShtRC++)
            {
                if (this.dtDailyGardAvailbitlySheet.Rows[gardAVLBShtRC]["ISASSIGNED"].ToString() == "Y")
                    continue;

                if (int.Parse(this.dtDailyGardAvailbitlySheet.Rows[gardAVLBShtRC]["GAURDCOUNT"].ToString()) != 0)
                    continue;

                postID =
                    this.dtDailyGardAvailbitlySheet.Rows[gardAVLBShtRC]["GS_POST_ID"].ToString();
                shiftID =
                    this.dtDailyGardAvailbitlySheet.Rows[gardAVLBShtRC]["GS_SHIFT_ID"].ToString();

                for (int dutyRC = 0; dutyRC <= this.dtNewDuty.Rows.Count - 1; dutyRC++)
                {
                    if (this.dtNewDuty.Rows[dutyRC]["ISONDUTY"].ToString() != "")
                        continue;

                    tm_NewDutyDate_lcoal =
                        DateTime.Parse(this.dtNewDuty.Rows[dutyRC]["DUTYDATE"].ToString());

                    if (this.tm_CurrentProcessingDate.Date.CompareTo(tm_NewDutyDate_lcoal.Date) != 0)
                        continue;

                    if (this.dtNewDuty.Rows[dutyRC]["GS_POST_ID"].ToString() == postID &&
                        this.dtNewDuty.Rows[dutyRC]["GS_SHIFT_ID"].ToString() == shiftID &&
                        this.dtNewDuty.Rows[dutyRC]["GS_GAURD_ID"].ToString() == "")
                    {
                        this.dtNewDuty.Rows[dutyRC]["ISONDUTY"] = "N";
                        this.dtNewDuty.Rows[dutyRC]["ISACTIVE"] = "Y";
                        //this.writeToFile(postID + "," + shiftID + ",");
                        break;
                    }
                }
            }
        }


        private bool isGaurdAssigned(string gaurdID)
        {

            for (int dutyAVLBShtRC = 0;
                    dutyAVLBShtRC <= this.dtDailyDutyAvailbitlySheet.Rows.Count - 1; dutyAVLBShtRC++)
            {
                if (this.dtDailyDutyAvailbitlySheet.Rows[dutyAVLBShtRC]["GS_GAURD_ID"].ToString() == gaurdID)
                {
                    if (this.dtDailyDutyAvailbitlySheet.Rows[dutyAVLBShtRC]["ISASSIGNED"].ToString() == "Y" ||
                        int.Parse(this.dtDailyDutyAvailbitlySheet.Rows[dutyAVLBShtRC]["DUTYCOUNT"].ToString()) == 0)
                        return true;
                    else
                        return false;
                }
            }
            return true;
        }

        private bool isDutyOccupied(string postID, string shiftID)
        {
            for (int gardAVLBShtRC = 0;
                    gardAVLBShtRC <= this.dtDailyGardAvailbitlySheet.Rows.Count - 1; gardAVLBShtRC++)
            {
                if (this.dtDailyGardAvailbitlySheet.Rows[gardAVLBShtRC]["GS_POST_ID"].ToString() == postID &&
                    this.dtDailyGardAvailbitlySheet.Rows[gardAVLBShtRC]["GS_SHIFT_ID"].ToString() == shiftID)
                {
                    if (this.dtDailyGardAvailbitlySheet.Rows[gardAVLBShtRC]["ISASSIGNED"].ToString() == "Y" ||
                        int.Parse(this.dtDailyGardAvailbitlySheet.Rows[gardAVLBShtRC]["GAURDCOUNT"].ToString()) == 0)
                        return true;
                    else
                        return false;
                }
            }
            return true;
        }

        private bool isMinimumValueAssignment(string postID, string shiftID, string gaurdID)
        {
            if (this.isGaurdAssigned(gaurdID))
                return false;
            if (this.isDutyOccupied(postID, shiftID))
                return false;

            int minimumDutyCount =
                this.getMinimumPossibleNumberOfDuties();
            int minimumGaurdCount =
                this.getMinimumPossibleNumberOfGaurds();

            string postID_local = "";
            string shiftID_local = "";
            string gaurdID_local = "";



            if (minimumDutyCount < minimumGaurdCount)
            {
                DataTable dtMinDutyGaurds_local = new DataTable();

                dtMinDutyGaurds_local =
                    this.getAllGaurdsWithMinimumPossibleDutiesAvailable();

                for (int rowCount = 0; rowCount <= dtMinDutyGaurds_local.Rows.Count - 1; rowCount++)
                {
                    gaurdID_local =
                        dtMinDutyGaurds_local.Rows[rowCount]["GS_GAURD_ID"].ToString();
                    if (gaurdID == gaurdID_local)
                        return true;
                }
                return false;
            }
            else if (minimumDutyCount > minimumGaurdCount)
            {

                DataTable dtMinGaurdDuties_local = new DataTable();

                dtMinGaurdDuties_local =
                        this.getAllDutiesWithMinimumPossibleGaurdsAvailable();

                for (int rowCount = 0; rowCount <= dtMinGaurdDuties_local.Rows.Count - 1; rowCount++)
                {
                    postID_local =
                        dtMinGaurdDuties_local.Rows[rowCount]["GS_POST_ID"].ToString();
                    shiftID_local =
                        dtMinGaurdDuties_local.Rows[rowCount]["GS_SHIFT_ID"].ToString();
                    if (postID == postID_local && shiftID == shiftID_local)
                        return true;
                }
                return false;
            }
            else if (minimumDutyCount == minimumGaurdCount)
            {
                DataTable dtMinGaurdDuties_local = new DataTable();

                dtMinGaurdDuties_local =
                        this.getAllDutiesWithMinimumPossibleGaurdsAvailable();

                for (int rowCount = 0; rowCount <= dtMinGaurdDuties_local.Rows.Count - 1; rowCount++)
                {
                    postID_local =
                        dtMinGaurdDuties_local.Rows[rowCount]["GS_POST_ID"].ToString();
                    shiftID_local =
                        dtMinGaurdDuties_local.Rows[rowCount]["GS_SHIFT_ID"].ToString();
                    if (postID == postID_local && shiftID == shiftID_local)
                        return true;
                }
                return false;
            }
            return false;
        }

        private void scavangeAssignment()
        {
            List<string> assignableGaurds = new List<string>();
            List<string[,]> unAssignedDuties = new List<string[,]>();

            string gaurdID_Local;
            string gaurdPreviousShift;

            for (int dutyAVLBShtRC = 0;
                    dutyAVLBShtRC <= this.dtDailyDutyAvailbitlySheet.Rows.Count - 1; dutyAVLBShtRC++)
            {
                if (this.dtDailyDutyAvailbitlySheet.Rows[dutyAVLBShtRC]["ISASSIGNED"].ToString() == "Y")
                    continue;

                gaurdID_Local =
                    this.dtDailyDutyAvailbitlySheet.Rows[dutyAVLBShtRC]["GS_GAURD_ID"].ToString();

                gaurdPreviousShift =
                    this.getPreviousShift(gaurdID_Local, this.tm_CurrentProcessingDate);

                // Gaurds Which Attend Night Shift The Previous Day Should Be Day OFF the Next Day.
                if (gaurdPreviousShift != offDutyShiftkey &&
                    gaurdPreviousShift != newGaurdkey &&
                    this.isNightShift(gaurdPreviousShift))
                    continue;

                assignableGaurds.Add(gaurdID_Local);
            }

            if (assignableGaurds.Count <= 0)
                return;


            string postID = "";
            string shiftID = "";


            for (int gardAVLBShtRC = 0;
                gardAVLBShtRC <= this.dtDailyGardAvailbitlySheet.Rows.Count - 1; gardAVLBShtRC++)
            {
                if (this.dtDailyGardAvailbitlySheet.Rows[gardAVLBShtRC]["ISASSIGNED"].ToString() == "Y")
                    continue;

                if (int.Parse(this.dtDailyGardAvailbitlySheet.Rows[gardAVLBShtRC]["GAURDCOUNT"].ToString()) != 0)
                    continue;

                postID =
                    this.dtDailyGardAvailbitlySheet.Rows[gardAVLBShtRC]["GS_POST_ID"].ToString();
                shiftID =
                    this.dtDailyGardAvailbitlySheet.Rows[gardAVLBShtRC]["GS_SHIFT_ID"].ToString();
                
                unAssignedDuties.Add(new string[,] {{postID, shiftID}});
            }

            if (unAssignedDuties.Count <= 0)
                return;

            int assignableGaurdCount = assignableGaurds.Count;
            int unAssignedDutyCount = unAssignedDuties.Count;

            int selectedDutyIndex;
            int selectedGaurdIndex;

            while (assignableGaurds.Count > 0 && unAssignedDuties.Count > 0)
            {
                selectedGaurdIndex =
                    this.getRandomNumber(0, assignableGaurds.Count);

                gaurdID_Local =
                    assignableGaurds[selectedGaurdIndex];

                selectedDutyIndex =
                    this.getRandomNumber(0, unAssignedDuties.Count);

                postID = unAssignedDuties[selectedDutyIndex][0, 0];
                shiftID = unAssignedDuties[selectedDutyIndex][0, 1];

                this.creatAssignment(this.tm_CurrentProcessingDate, postID, shiftID, gaurdID_Local);

                assignableGaurds.RemoveAt(selectedGaurdIndex);
                unAssignedDuties.RemoveAt(selectedDutyIndex);
            }
        }
    }

}
