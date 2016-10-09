using System;
using System.Collections.Generic;
using System.Text;

namespace DianDang
{
    public class ToChineseValue
    {        
        private enum chineseChar{零,壹,贰,叁,肆,伍,陆,柒,捌,玖};
        private enum charValue{个=1,十,百,千}
        private enum c{元=1,万,亿,兆};
        private enum afterPoint{角,分};
        public ToChineseValue()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }
        public string toChineseChar(decimal d)
        {
            decimal flag=0;
            if(d<0)
            {
                flag=d;
                d=-d;
            }
            
            string strChinese="";
            string nextString="";

            System.Globalization.NumberFormatInfo fmat=new System.Globalization.NumberFormatInfo();
            fmat.CurrencyDecimalDigits=2;            
            fmat.CurrencySymbol="";                
            fmat.CurrencyGroupSizes =new int []{4,4,4,4};
            fmat.CurrencyGroupSeparator=",";

            string strx=d.ToString("c",fmat);        
            string []afterArray=strx.ToString() .Split ('.');

            char[] prePoint=afterArray[0].ToCharArray ();
            char [] nextChar=afterArray[1].ToCharArray ();                
            
            if(System.Convert .ToDecimal (afterArray[0].ToString ())==0)
            { strChinese="";}
            else
            {            
                string [] str=afterArray[0].ToString().Split (',');
                int Num=str.Length ;        
                //交错数组用来放四个一组的数组
                char[][]part=new char [Num][];        
                for(int i=0;i<str.Length ;i++)
                {                
                    part[i]=str[i].ToCharArray ();                
                }        
                for(int i=0;i<Num;i++)
                {                
                    for(int j=0;j<part[i].Length;j++)                
                    {
                        //用枚举完成汉字的转换
                        strChinese+=((chineseChar)int.Parse (part[i][j].ToString ())).ToString ();
                        //用枚举完成单位: 个 十 百 千 
                        strChinese+=((charValue)(part[i].Length-j)).ToString();                        
                    }    
                    //以下为处理元 万 亿 兆 
                    strChinese+=((c)(part.Length-i)).ToString();
                }                
            }            
            //处理点号后面的小数部分        
            if(System.Convert.ToDecimal(afterArray[1].ToString ())==0&&System.Convert.ToDecimal(afterArray                           [0].ToString ())!=0)
            {
                nextString="整";
            }
            else
            {    
                for(int i=0;i<2;i++)
                {    
                    int t=int.Parse (nextChar[i].ToString ());                
                    nextString+=((chineseChar)int.Parse (nextChar[i].ToString ())).ToString ();
                    nextString+=((afterPoint)(i)).ToString();
                    if(t==0)
                    {
                        StringBuilder str=new StringBuilder(nextString);                                            
                        nextString=str.Replace ("零零","零").ToString ();
                        nextString=str.Replace ("零角零分","零元").ToString ();                        
                    }
                }                
            }                
            StringBuilder sb=new StringBuilder(strChinese);    
            for(int i=0;i<4;i++)
            {    
                strChinese=sb.Replace ("个","").ToString ();                
                strChinese=sb.Replace ("零元","元").ToString ();
                strChinese=sb.Replace ("零万","万").ToString ();
                strChinese=sb.Replace ("亿万","亿").ToString ();
                strChinese=sb.Replace ("零亿","亿").ToString ();
                strChinese=sb.Replace ("零十","零").ToString ();
                strChinese=sb.Replace ("零百","零").ToString ();
                strChinese=sb.Replace ("零千","零").ToString ();
                strChinese=sb.Replace ("零零","零").ToString ();
                strChinese=sb.Replace ("零角零分","整").ToString ();
            }
            if(flag>=0)
            {
                return strChinese+nextString;
            }
            return "负"+strChinese+nextString;
        }
    }
}
