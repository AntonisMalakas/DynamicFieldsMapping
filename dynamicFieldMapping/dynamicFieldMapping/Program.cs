using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Dynamic;

namespace dynamicFieldMapping
{
    class Program
    {

        static void Main(string[] args)
        {
            List<ConcurrentDictionary<string, object>> conList1 = new List<ConcurrentDictionary<string, object>>();
            List<ConcurrentDictionary<string, object>> conList2 = new List<ConcurrentDictionary<string, object>>();

            ConcurrentDictionary<string, object> conDic1 = new ConcurrentDictionary<string, object>();
            ConcurrentDictionary<string, object> conDic11 = new ConcurrentDictionary<string, object>();
            ConcurrentDictionary<string, object> conDic111 = new ConcurrentDictionary<string, object>();

            ConcurrentDictionary<string, object> conDic2 = new ConcurrentDictionary<string, object>();
            ConcurrentDictionary<string, object> conDic22 = new ConcurrentDictionary<string, object>();
            ConcurrentDictionary<string, object> conDic222 = new ConcurrentDictionary<string, object>();



            conDic1["group_line_id"] = 1;
            conDic1["group_line_desc"] = "test desc";
            conDic1["label"] = "test label";
            conDic1["order"] = 1;
            conDic1["2012"] = 0;
            conDic1["2013"] = 0;
            conList1.Add(conDic1);

            conDic11["group_line_id"] = 2;
            conDic11["group_line_desc"] = "test desc 2";
            conDic11["label"] = "test label 2";
            conDic11["order"] = 1;
            conDic11["2012"] = 0;
            conDic11["2013"] = 0;
            conList1.Add(conDic11);

            conDic111["group_line_id"] = 3;
            conDic111["group_line_desc"] = "test desc 3";
            conDic111["label"] = "test label 3";
            conDic111["order"] = 1;
            conDic111["2012"] = 0;
            conDic111["2013"] = 0;
            conList1.Add(conDic111);


            conDic2["group_line_id"] = 1;
            conDic2["group_line_desc"] = "test desc";
            conDic2["2012"] = 12;
            conDic2["2013"] = 13;
            conList2.Add(conDic2);

            conDic22["group_line_id"] = 2;
            conDic22["group_line_desc"] = "test desc 2";
            conDic22["2012"] = 122;
            conDic22["2013"] = 133;
            conList2.Add(conDic22);

            conDic222["group_line_id"] = 3;
            conDic222["group_line_desc"] = "test desc 3";
            conDic222["2012"] = 1222;
            conDic222["2013"] = 1333;
            conList2.Add(conDic222);


            foreach (var item1 in conList1)
            {
                foreach (var item2 in conList2)
                {
                    if (item1["group_line_id"].ToString() == item2["group_line_id"].ToString())
                    {
                        foreach (KeyValuePair<string, object> field1 in item1)
                        {
                            foreach (KeyValuePair<string, object> field2 in item2)
                            {
                                if(field1.Key == field2.Key)
                                {
                                    item1.AddOrUpdate(field1.Key, field2.Value , (key, oldValue) => field2.Value);
                                    //item1[field1.Key.ToString()] = item2[field2.Key.ToString()];
                                }
                            }
                        }
                    }
                }
            }

            var final = conList1;


        }


    }
}
