namespace Leet;

public class NodeCases
{
    [Fact]
    public void Test1()
    {
        var l1 = ArrayToListNode(new[] { 2, 4, 3 });
        var l2 = ArrayToListNode(new[] { 5, 6, 4 });
        var ans = AddTwoNumbers(l1, l2);
    }

    private ListNode ArrayToListNode(int[] a)
    {
        var result = new ListNode();
        var current = result;
        for (var i = 0; i < a.Length; i++)
        {
            current.next = new ListNode(a[i]);
            current = current.next;
        }
        return result.next;
    }
    
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
    {
        var result=new ListNode();
        var current=result;
        var c=0;
        while (l1!=null && l2!=null)
        {
            var value=l1.val+l2.val+c;
            c=0;
            if (value>9)
            {
                c=1;
                value-=10;
            }

            current.next = new ListNode(value);
            current = current.next;
            l1=l1.next;
            l2=l2.next;
        }

        while (l1 != null)
        {
            var value = l1.val + c;
            c = 0;
            if (value > 9)
            {
                c = 1;
                value -= 10;
            }
            current.next = new ListNode(value);
            current = current.next;
            l1 = l1.next;
        }

        while (l2 != null)
        {
            var value = l2.val + c;
            c = 0;
            if (value > 9)
            {
                c = 1;
                value -= 10;
            }
            current.next = new ListNode(value);
            current = current.next;
            l2 = l2.next;
        }

        if (c==1)
        {
            current.next= new ListNode(1);
        }
        return result.next;
    }
}