using System;
using System.Collections.Generic;
using System.Collections;
/**
 * Definition for singly-linked list.
  public class ListNode {
      public int val;
      public ListNode next;
      public ListNode(int val=0, ListNode next=null) {
          this.val = val;
          this.next = next;
      }
 
  }
 * list1 = [1,2,4], list2 = [1,3,4]
 * [1,1,2,3,4,4]
 */

public class ListNode
{
    public int val;
    public ListNode next;
    public ListNode(int val = 0, ListNode next = null)
    {
        this.val = val;
        this.next = next;
    }

}



public class Solution
{


    public static void Main()
    {
        ListNode list1 = new ListNode();
        ListNode list2 = new ListNode();
        list1.val = 1;
        list1 = list1.next;
        list1.val = 2;
        list1 = list1.next;
        list1.val = 4;

        list2.val = 1;
        list2 = list2.next;
        list2.val = 3;
        list2 = list2.next;
        list2.val = 4;

        MergeTwoLists(list1, list2);
    }
    public static ListNode MergeTwoLists(ListNode list1, ListNode list2)
    {


        ListNode list3 = new ListNode();

        while (list1 != null && list2 != null)
        {
            if (list1.val <= list2.val)
            {
                list3.next = list1;
                list1 = list1.next;
            }
            else
            {
                list3.next = list2;
                list2 = list2.next;
            }
        }
        return list3;
    }
}