using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class PlayerPrefsDataMgr
{
    //单例模式
    private static PlayerPrefsDataMgr PlayerPrefsDataMgrs = new PlayerPrefsDataMgr();
    public static PlayerPrefsDataMgr player
    {
        get
        {
           return PlayerPrefsDataMgrs;
        }
    }
    private PlayerPrefsDataMgr()
    {

    }
    public void DataSave(object data,string KeyName)
    {
        //获得对象属性
        Type datas = data.GetType();
        //获得对象属性上的所有字段
        FieldInfo[] info = datas.GetFields();
        //暂时存kename用来拼接
        string saveKeyName="";
        //创建一个infoFeild对象用来接收临时的info数组里的字节
        FieldInfo infos;
        //有多少对象，循环多少次拼接,有多少次字段，存多少次
        //keyname_plaerInfo_int_age
        for (int i = 0; i <info.Length; i++)
        {
            infos = info[i];//每个字段都拼接一次
            //开始拼接
            saveKeyName = KeyName + "_" + datas.Name + "_" + infos.FieldType.Name + "_" + infos.Name;
            //键值已经拼接好了，开始存,单独创建一个方法封装
            //每一个字段都获取它的值
            save(infos.GetValue(data), saveKeyName);//infos.GetValue(data)会获得int age=10字段的值：10;
        }
        PlayerPrefs.Save();
    }
    private void save(object data,string mykey)
    {
        Type type = data.GetType();//获取属性
        if (type == typeof(int))
        {
            int value = (int)data;
            value += 10;
            PlayerPrefs.SetInt(mykey, value);
           
        }
        else if (type == typeof(float))
        {
            PlayerPrefs.SetFloat(mykey, (float)data);
            
        }
        else if (type == typeof(string))
        {
            PlayerPrefs.SetString(mykey, data.ToString());
           
        }
        else if (type == typeof(bool))
        {
            PlayerPrefs.SetInt(mykey, (bool)data ? 1 : 0);
            
        }
        else if (typeof(IList).IsAssignableFrom(type))//判断是不是list，只要是Ilist的子类就是List
        {
            
            IList list = data as IList;
            // IList list = data as IList;只会对data对象的list起作用，其他的int,float不管
            //将对象实例转换成IList存起来，把data里的list用一个
            //容器单独装起来，递归
            int index = 0;//使得list中的数据不会互相覆盖
            PlayerPrefs.SetInt(mykey, list.Count);//存一下list有多长
            foreach (object obj in list)
            {
                save(obj, mykey + index);
                ++index;
            }
        }
        else if (typeof(IDictionary).IsAssignableFrom(type))//判断是不是字典
        {
            IDictionary dictionary = data as IDictionary;//新容器装字典
            PlayerPrefs.SetInt(mykey, dictionary.Count);//存字典长度
            int index = 0;
            foreach (object obj in dictionary.Keys)//循坏将键值对存进去
            {
                //因为字典键值都有类型，所以都要挨个存，但是在一个循环里存的
                //所以会紧挨着
                save(obj, mykey + "_Key_" + index);//存键
                save(dictionary[obj], mykey + "_Value_" + index);//字典[键]=值，存值
                ++index;
            }
        }
        else
        {
            DataSave(data, mykey);
        }
        
    }
    /// <summary>
    /// 读取数据
    /// </summary>
    /// <param name="type">想要读取数据的 数据类型Type</param>
    /// <param name="keyName">数据对象的唯一key 自己控制</param>
    /// <returns></returns>
    public object DataLoad(Type type,string KeyName)
    {
        //不用object对象传入 而使用 Type传入
        //主要目的是节约一行代码（在外部）
        //假设现在你要 读取一个Player类型的数据 如果是object 你就必须在外部new一个对象传入
        //现在有Type的 你只用传入 一个Type typeof(Player) 然后我在内部动态创建一个对象给你返回出来
        //达到了 让你在外部 少写一行代码的作用

        //根据你传入的类型 和 keyName
        //依据你存储数据时  key的拼接规则 来进行数据的获取赋值 返回出去

        //根据传入的Type 创建一个对象 用于存储数据
        object data = Activator.CreateInstance(type);//快速创建playerInfo对象
        //要往这个new出来的对象中存储数据 填充数据
        //得到所有字段
        FieldInfo[] infos= type.GetFields();
        FieldInfo _info;
        string loadKeyName = "";
        for (int i = 0; i < infos.Length; i++)//拼接成存进去的样子就能找到取出来了
        {
            _info = infos[i];
            loadKeyName = KeyName + "_" + type.Name + "_"+_info.FieldType.Name+"_"+_info.Name;
            _info.SetValue(data,Load(_info.FieldType,loadKeyName));//将load返回的值int age=10,存到data对象中_info字段
        }
        return data;
    }
    public object Load(Type type, string mykey)
    {
        if (type == typeof(int))
        {
            //Debug.Log($"GetInt {mykey}");
            return PlayerPrefs.GetInt(mykey, 0)-10;
        }
        else if (type == typeof(float))
        {
            //Debug.Log($"GetFloat {mykey}");
            return PlayerPrefs.GetFloat(mykey, 0);
        }
        else if (type == typeof(string))
        {
            //Debug.Log($"GetString {mykey}");
            return PlayerPrefs.GetString(mykey, "");
        }
        else if (type == typeof(bool))
        {
            return PlayerPrefs.GetInt(mykey, 0) == 1 ? true : false;//三目运算符，如果1则返回true,否则返回false
        }
        else if (typeof(IList).IsAssignableFrom(type))
        {
            IList list = Activator.CreateInstance(type)as IList;//传进来列表属性就要用列表先存起来
            int count= PlayerPrefs.GetInt(mykey);
            for (int i = 0; i < count; i++)
            {
                list.Add(Load(type.GetGenericArguments()[0],mykey+i));
            }
            return list;
        }
        else if (typeof(IDictionary).IsAssignableFrom(type))
        {
            //实例化一个字典对象 用父类装子类
            IDictionary dictionary = Activator.CreateInstance(type)as IDictionary;
            //得到字典的长度
            int count = PlayerPrefs.GetInt(mykey);
            //得到字典的两个泛型<int,string>
            Type[] types=type.GetGenericArguments();
            for (int i = 0; i < count; i++)
            {
                dictionary.Add(Load(types[0], mykey+"_Key_" +i)/*键的泛型,key的值*/
                               ,Load(types[1],mykey+ "_Key_" + i)/*值的泛型，key的值*/);
            }
            return dictionary;
        }
        else
        {
            //重新调用DataLoad将自定义类拼接key，然后再次根据类型load里取出来
            return DataLoad(type, mykey);
        }
    }
}
