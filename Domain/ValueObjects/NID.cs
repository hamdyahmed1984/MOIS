using Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Domain.ValueObjects
{
    public sealed class NID : ValueObject
    {
        public string NationalIdenNumber { get; private set; }
        const string RegExForValidation = @"^\d{14}$";

        private NID() { }
        public NID(string nid)
        {
            if (string.IsNullOrWhiteSpace(nid))
                throw new ShouldNotBeEmptyException("The 'nid' field is required");

            Regex regex = new Regex(RegExForValidation);
            Match match = regex.Match(nid);

            if (!match.Success)
                throw new InvalidFormatException("Invalid NID format. Use 14 digits.");

            NationalIdenNumber = nid;
        }

        public override string ToString()
        {
            return $"{NationalIdenNumber}";
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return NationalIdenNumber;
        }

        public bool IsNidValid()
        {
            //if (NationalIdenNumber.Length != 14)//This is needed as we check for length in the constructor
            //    return false;
            int num = Convert.ToInt32(NationalIdenNumber[0].ToString());
            int num2 = Convert.ToInt32(NationalIdenNumber[1].ToString());
            int num3 = Convert.ToInt32(NationalIdenNumber[2].ToString());
            int num4 = Convert.ToInt32(NationalIdenNumber[3].ToString());
            int num5 = Convert.ToInt32(NationalIdenNumber[4].ToString());
            int num6 = Convert.ToInt32(NationalIdenNumber[5].ToString());
            int num7 = Convert.ToInt32(NationalIdenNumber[6].ToString());
            int num8 = Convert.ToInt32(NationalIdenNumber[7].ToString());
            int num9 = Convert.ToInt32(NationalIdenNumber[8].ToString());
            int num10 = Convert.ToInt32(NationalIdenNumber[9].ToString());
            int num11 = Convert.ToInt32(NationalIdenNumber[10].ToString());
            int num12 = Convert.ToInt32(NationalIdenNumber[11].ToString());
            int num13 = Convert.ToInt32(NationalIdenNumber[12].ToString());
            int num14 = Convert.ToInt32(NationalIdenNumber[13].ToString());
            int num15 = num * 2;
            int num16 = num2 * 7;
            int num17 = num3 * 6;
            int num18 = num4 * 5;
            int num19 = num5 * 4;
            int num20 = num6 * 3;
            int num21 = num7 * 2;
            int num22 = num8 * 7;
            int num23 = num9 * 6;
            int num24 = num10 * 5;
            int num25 = num11 * 4;
            int num26 = num12 * 3;
            int num27 = num13 * 2;
            int num28 = num15 + num16 + num17 + num18 + num19 + num20 + num21 + num22 + num23 + num24 + num25 + num26 + num27;
            int num29 = unchecked(num28 % 11);
            int num30 = 11 - num29;
            switch (num30)
            {
                case 11:
                    num30 = 1;
                    break;
                case 10:
                    num30 = 0;
                    break;
            }
            if (num30 == num14)
                return true;
            return false;
        }

        public string GetGender()
        {
            char expression = NationalIdenNumber[12];
            int num = Convert.ToInt32(expression);
            if (num % 2 != 0)
            {
                return "ذكر";
            }
            return "أنثى";
        }

        public DateTime GetDateOfBirth()
        {
            char expression = NationalIdenNumber[0];
            char value = NationalIdenNumber[1];
            char value2 = NationalIdenNumber[2];
            char value3 = NationalIdenNumber[3];
            char value4 = NationalIdenNumber[4];
            char value5 = NationalIdenNumber[5];
            char value6 = NationalIdenNumber[6];
            string strYear = default(string);
            switch (expression)
            {
                case '1':
                    strYear = "18" + value + value2;
                    break;
                case '2':
                    strYear = "19" + value + value2;
                    break;
                case '3':
                    strYear = "20" + value + value2;
                    break;
            }
            string strMonth = value3.ToString() + value4.ToString();
            string strDay = value5.ToString() + value6.ToString();
            int year = Convert.ToInt32(strYear);
            int month = Convert.ToInt32(strMonth);
            int day = Convert.ToInt32(strDay);
            DateTime dateTime = new DateTime(year, month, day);
            return dateTime;
        }
        public string GetGovernorate()
        {
            char value = NationalIdenNumber[7];
            char value2 = NationalIdenNumber[8];
            string governorateCode = value.ToString() + value2.ToString();
            switch (Convert.ToInt32(governorateCode))
            {
                case 1:
                    return "محافظة القاهرة";
                case 11:
                    return "محافظة دمياط";
                case 12:
                    return "محافظة الدقهلية";
                case 13:
                    return "محافظة الشرقية";
                case 14:
                    return "محافظة القليوبية";
                case 15:
                    return "محافظة كفر الشيخ";
                case 16:
                    return "محافظة الغربية";
                case 17:
                    return "محافظة المنوفية";
                case 18:
                    return "محافظة البحيرة";
                case 19:
                    return "محافظة الإسماعلية";
                case 2:
                    return "محافظة الأسكندرية";
                case 21:
                    return "محافظة الجيزة";
                case 22:
                    return "محافظة بني سويف";
                case 23:
                    return "محافظة الفيوم";
                case 24:
                    return "محافظة المنيا";
                case 25:
                    return "محافظة أسيوط";
                case 26:
                    return "محافظة سوهاج";
                case 27:
                    return "محافظة قنا";
                case 28:
                    return "محافظة أسوان";
                case 29:
                    return "محافظة الأقصر";
                case 3:
                    return "محافظة بورسعيد";
                case 31:
                    return "محافظة البحر الأحمر";
                case 32:
                    return "محافظة الوادي الجديد";
                case 33:
                    return "محافظة مطروح";
                case 34:
                    return "محافظة شمال سيناء";
                case 35:
                    return "محافظة جنوب سيناء";
                case 4:
                    return "محافظة السويس";
                case 5:
                    return "محافظة حلوان";
                case 6:
                    return "محافظة السادس من أكتوبر";
                case 88:
                    return "خارج الجمهورية";
                case 99:
                    return "خارج الجمهورية";
                default:
                    {
                        return string.Empty;
                    }
            }
        }
    }
}
