public static class PhoneNumber
{
    public static (bool IsNewYork, bool IsFake, string LocalNumber) Analyze(string phoneNumber)
    {
        bool q = false;
        bool w = false;
        string e = phoneNumber.Split('-')[2];
        
        if (phoneNumber.Split('-')[0] == "212")
        {
            q = true;
        }
        else 
        {
            q = false;
        }

        if (phoneNumber.Split('-')[1] == "555")
        {
            w = true;
        }
        else
        {
            w = false;
        }

        return (q, w, e);
    }

    public static bool IsFake((bool IsNewYork, bool IsFake, string LocalNumber) phoneNumberInfo)
    {
        bool q = phoneNumberInfo.IsNewYork;
        bool w = phoneNumberInfo.IsFake;
        string e = phoneNumberInfo.LocalNumber;

        if (w)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
