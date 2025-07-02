using System;
using System.Data;
namespace a
{
    class Program
    {
      private static string fmtactstr = "{0}{1,4}  {2,4} {3,4} {4,7}  {5,4} {6,4} {7,7}      {8,7}           {9,3}\n";
        private static String Act2S(string x, int c)
        {
            System.Text.Encoding encodeUTF8 = System.Text.Encoding.UTF8;
            int utf7_cnt = encodeUTF8.GetByteCount(x);
            int tempint = x.Length * 2 - (x.Length * 3 - utf7_cnt) / 2;
            c = tempint > 57 ? (c + 57 * 2 - 3) : c;
            String pattern = "[- )(a-zA-Z0-9]";
            System.Text.RegularExpressions.Regex rgx = new System.Text.RegularExpressions.Regex(pattern);
            int eng = rgx.Matches(x).Count;
            int chn =( utf7_cnt-eng ) /3;
            Console.WriteLine("c3e1={0}-{1}, chn={2}-eng={3}-c={4}",utf7_cnt,tempint,chn,eng, c);
            for (int i = (chn*2+eng); i < (c ); i++) x += " ";
            return x;
        }
        public static String a2g(String x){ return x; }
        public static String ACTFMT(String act_py,String grade1,String grade2,String grade3,  int mask_flag)
        {
                string x = string.Format("活動課-{0}", act_py);
                return                   
                     string.Format(fmtactstr,
               Act2S(x, 35),
               ((mask_flag & 1) == 1 ? a2g(grade1) + " " : "--"),
               "", "",
               ((mask_flag & 2) == 2 ? a2g(grade2) + " " : "--"),
               "", "",
               ((mask_flag & 4) == 4 ? a2g(grade3) + " " : "--"),
               "", ""
               );
        }
        static void Main(string[] args)
        {
String lines=@"STEM初階---VEX GO機械人班
VEX IQ未來之星機械人培訓課程
We do創意機械人
初小乒乓球興趣班
初小劍撃班
初小小提琴初級A班
初小小提琴初級B班
初小柔道班
初小籃球興趣A班
初小籃球興趣B班
初小籃球興趣C班
初小羽毛球班
初小藝術啟蒙班
初小足球A班
初小足球B班
初小跆拳道興趣班
唱遊樂紛紛
小學中長跑訓練班
小學創意科技班
小學戲劇班
小學無人機班
小學網球班
小學舞蹈啓蒙班
小學舞蹈團
小學藝術興趣班
小學趣味編程班
少兒趣味田徑班
智慧遊戲創意工作坊
樂高創意機械人
短片拍攝及製作興趣班
趣味軟式排球A班
趣味軟式排球B班
高小中提琴班
高小乒乓球班
高小五子棋班
高小劍撃班
高小合唱興趣班
高小小提琴A班
高小小提琴B班
高小手球班
高小柔道班
高小籃球興趣A班
高小籃球興趣B班
高小籃球興趣B班(五六年級)
高小籃球興趣C班
高小籃球興趣C班(三四年級)
高小羽毛球班
高小趣味排球A班
高小趣味排球B班
高小趣味田徑A班
高小趣味田徑B班
高小足球A班
高小足球B班
高小跆拳道興趣班
鼓樂好玩最啱我";
          foreach (string line in lines.Split(new[] { "\r\n", "\n" }, StringSplitOptions.None))
            Console.Write(ACTFMT(line,"A","B+","C-",7));
        }
     }
}