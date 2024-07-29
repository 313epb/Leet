namespace Leet;

public class Common
{
    #region Длинна наибольшей строки с уникальным символами

    [Fact]
    public void SubstringLength()
    {
        var result = LengthOfLongestSubstring("pwwkew");
    }

    public int LengthOfLongestSubstring(string s) {
        if (string.IsNullOrEmpty(s)) return 0;
        if (s.Length==1) return 1;
        var left=0;
        var max=1;
        for (var right=1;right<s.Length;right++)
        {
            if (!s.Substring(left,right-left).Contains(s[right])){
                max=Math.Max(max,right-left+1);
            }
            else
            {
                left =s.Substring(left,right-left).IndexOf(s[right])+left+1;
            }
        }
        return max;
    }
    #endregion

    #region Длинна наибольшего палиндрома в строке

    [Fact]
    public void MaxPalindromeSubstring()
    {
        var result = LongestPalindrome("ccc");
    }
    
    public string LongestPalindrome(string s) {
        if (string.IsNullOrEmpty(s)||s.Length==1) return s;
        var result=s[0].ToString();
        for (var i=0; i<s.Length;i++){
            var odd=MaxPalindromeForCurrentChar(s, i, 0);
            var even=MaxPalindromeForCurrentChar(s, i, 1);
            result = result.Length >= Math.Max(odd.Length, even.Length) 
                ? result 
                : odd.Length > even.Length 
                    ? odd 
                    : even;
        }
        return result;
    }

    private string MaxPalindromeForCurrentChar(string s, int pos, int odd){
        var result=s[pos].ToString();
        for (var i=0;i<s.Length;i++)
        {
            if (i  + 1 + odd + pos > s.Length || pos - i < 0) return result;
            if (!IsPalindrome(s.Substring(pos-i, i+i+1+odd))){
                return result;
            }
            result=s.Substring(pos-i, i+i+1+odd);
        }
        return result;
    }

    private bool IsPalindrome(string s){
        char[] array = s.ToCharArray();
        Array.Reverse(array);
        return s==new String(array);
    }

    #endregion

    #region ЗигЗаг преобразование

    [Fact]
    public void ZigZagConversion()
    {
        var s = "PAYPALISHIRING";
        var result = Convert(s, 4);
        var foo = result == "PINALSIGYAHRPI";
    }
    
    public string Convert(string s, int k) {
        if (string.IsNullOrEmpty(s)) return s;
        if (k==1) return s;
        var result="";

        for (var j = 1; j <= k; j++)
        {
            var c=1;
            var pointer=1;
            for (var i = 0; i < s.Length; i++)
            {
                if (c == j)
                {
                    result += s[i].ToString();
                }
                if (c==k) pointer=-1;
                if (c==1) pointer=1;
                c += pointer;
            }
        }
        return result;
    }

    #endregion

    #region Atoi 

    [Fact]
    public void Atoi()
    {
        var result = MyAtoi("42");
    }
    public int MyAtoi(string s)
    {
        if (string.IsNullOrEmpty(s)) return 0;
        var result="";
        for (var i=0;i<s.Length;i++){
            if (char.IsLetter(s[i]) || s[i] == '.')
            {
                break;
            }

            if (s[i] == ' ')
            {
                if (!string.IsNullOrEmpty(result)) break;
                continue;
            }

            if (s[i] == '+' || s[i] == '-')
            {
                if (!string.IsNullOrEmpty(result))
                {
                    break;
                }
            }
            result += s[i];
        }

        if (string.IsNullOrEmpty(result)) return 0;
        if (!result.Any(char.IsDigit)) return 0;


        
        if (int.TryParse(result, out var newOne))
        {
            return newOne;
        }
        
        return result.Contains('-') ? int.MinValue : int.MaxValue;
    }

    #endregion

    #region Преобразование в римские цифры

    [Fact]
    public void RomanNums()
        
    {
        var result = IntToRoman(1994);
    }
    
    public string IntToRoman(int num)
    {
        var romanOnes = new Dictionary<int, string> { { 0, "I" }, { 1, "X" }, { 2, "C" }, {3,"M"} };
        var romanFiths = new Dictionary<int, string> { { 0, "V" }, { 1, "L" }, { 2, "D" } };
        var result = "";
        var i = 0;
        while (num>0)
        {
            var c = num % 10;
            if (c == 4)
            {
                result = romanOnes[i] + romanFiths[i] + result;
            }
            else if (c==9)
            {
                result = romanOnes[i] + romanOnes[i+1] + result;
            }
            else if (c!=0)
            {
                while (c > 0)
                {
                    if (c== 5)
                    {
                        result = romanFiths[i] + result;
                        break;
                    }

                    result = romanOnes[i] + result;
                    c--;
                }
            }
            num /= 10;
            i++;
        }
        return result;
    }

    
    #endregion

    #region Сумма 3х

    [Fact]
    public void Sum3()
    {
        var result = ThreeSum(new[] { -2,0,0,2,2 });
    }

    public IList<IList<int>> ThreeSum(int[] a)
    {
        var result = new List<IList<int>>();
        Array.Sort(a);
        for (var i = 0; i < a.Length; i++)
        {
            int j = i + 1,
                k = a.Length - 1;
            while (j < k)
            {

                if (a[i] + a[j] + a[k] == 0)
                {
                    result.Add(new List<int> { a[i], a[j], a[k] });
                }
                if (a[i] + a[j] + a[k] == 0)
                {
                    while (k>j && a[k]==a[k-1])
                    {
                        k--;
                    }

                    k--;
                    while (k>j && a[j]==a[j+1])
                    {
                        j++;
                    }

                    j++;
                }
                else if (a[i] + a[j] + a[k] > 0)
                {
                    while (k>j && a[k]==a[k-1])
                    {
                        k--;
                    }

                    k--;
                }
                else if (a[i] + a[j] + a[k] < 0)
                {
                    while (k>j && a[j]==a[j+1])
                    {
                        j++;
                    }

                    j++;
                }

            }

            while (i < a.Length - 2 && a[i] == a[i + 1]) i++;
        }

        return result;
    }

    #endregion

    #region Сумма трёх ближе всего

    [Fact]
    public void ThreeClosest()
    {
        var result = ThreeSumClosest(new []{-1,2,1-4} , 1);
    }
    
    public int ThreeSumClosest(int[] nums, int target) {
        Array.Sort(nums);
        var max=Math.Abs(nums[0]+nums[1]+nums[2]-target);
        var result=nums[0]+nums[1]+nums[2];
        for (var i=0;i<nums.Length;i++){
            var j=i+1;
            var k=nums.Length-1;
            while (k>j){
                var current=nums[i]+nums[k]+nums[j];
                if (Math.Abs(current-target)<max){
                    max=Math.Abs(current-target);
                    result=current;
                }
                if (current-target>0){
                    k--;
                }
                if (current-target<0){
                    j++;
                }
                if (current==target){
                    return result;
                }
            }
        }
        return result;
    }

    #endregion

    #region Комбинация символов телефон

    [Fact]
    public void PhoneCombine()
    {
        var result = LetterCombinations("");
    }
    
    public IList<string> LetterCombinations(string digits)
    {
        if (string.IsNullOrEmpty(digits)) return new List<string>();
        var result = new List<string>{""};
        for (int i = 0; i < digits.Length; i++)
        {
            result=DecardLists(result, _phoneLetters[digits[i].ToString()].ToList());
        }

        return result;
    }

    public List<string> DecardLists(List<string> source, List<char> multi)
    {
        var result = new List<string>();
        foreach (var s in source)
        {
            foreach (var m in multi)
            {
                result.Add(s+m);
            }
        }
        return result;
    }

    private Dictionary<string, string> _phoneLetters = new Dictionary<string, string>
    {
        { "2", "abc" },
        { "3", "def" },
        { "4", "ghi" },
        { "5", "jkl" },
        { "6", "mno" },
        { "7", "pqrs" },
        { "8", "tuv" },
        { "9", "wxyz" },

    };

    #endregion
}