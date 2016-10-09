using System;
using System.Collections.Generic;
using System.Text;

namespace DianDang
{
    public class ToChineseValue
    {        
        private enum chineseChar{��,Ҽ,��,��,��,��,½,��,��,��};
        private enum charValue{��=1,ʮ,��,ǧ}
        private enum c{Ԫ=1,��,��,��};
        private enum afterPoint{��,��};
        public ToChineseValue()
        {
            //
            // TODO: �ڴ˴���ӹ��캯���߼�
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
                //���������������ĸ�һ�������
                char[][]part=new char [Num][];        
                for(int i=0;i<str.Length ;i++)
                {                
                    part[i]=str[i].ToCharArray ();                
                }        
                for(int i=0;i<Num;i++)
                {                
                    for(int j=0;j<part[i].Length;j++)                
                    {
                        //��ö����ɺ��ֵ�ת��
                        strChinese+=((chineseChar)int.Parse (part[i][j].ToString ())).ToString ();
                        //��ö����ɵ�λ: �� ʮ �� ǧ 
                        strChinese+=((charValue)(part[i].Length-j)).ToString();                        
                    }    
                    //����Ϊ����Ԫ �� �� �� 
                    strChinese+=((c)(part.Length-i)).ToString();
                }                
            }            
            //�����ź����С������        
            if(System.Convert.ToDecimal(afterArray[1].ToString ())==0&&System.Convert.ToDecimal(afterArray                           [0].ToString ())!=0)
            {
                nextString="��";
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
                        nextString=str.Replace ("����","��").ToString ();
                        nextString=str.Replace ("������","��Ԫ").ToString ();                        
                    }
                }                
            }                
            StringBuilder sb=new StringBuilder(strChinese);    
            for(int i=0;i<4;i++)
            {    
                strChinese=sb.Replace ("��","").ToString ();                
                strChinese=sb.Replace ("��Ԫ","Ԫ").ToString ();
                strChinese=sb.Replace ("����","��").ToString ();
                strChinese=sb.Replace ("����","��").ToString ();
                strChinese=sb.Replace ("����","��").ToString ();
                strChinese=sb.Replace ("��ʮ","��").ToString ();
                strChinese=sb.Replace ("���","��").ToString ();
                strChinese=sb.Replace ("��ǧ","��").ToString ();
                strChinese=sb.Replace ("����","��").ToString ();
                strChinese=sb.Replace ("������","��").ToString ();
            }
            if(flag>=0)
            {
                return strChinese+nextString;
            }
            return "��"+strChinese+nextString;
        }
    }
}
