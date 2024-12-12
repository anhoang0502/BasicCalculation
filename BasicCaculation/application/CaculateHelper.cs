using System;
using System.Collections.Generic;


namespace BasicCaculation.application
{
    public static class CaculateHelper
    {
        public static MyStack XuLyBieuThuc(string bieuthuc) //Thao tác chuyển
        {
            MyStack ketqua = new MyStack(); // Ngăn xếp số
            MyStack toantu = new MyStack();    // Ngăn xếp toán tử

            // Thay thế các ký tự toán học đặc biệt bằng ký tự dễ xử lý
            bieuthuc = bieuthuc.Replace("÷", "/").Replace("×", "*"); 

            string[] bieuthucs = KhoangTrang(bieuthuc);

            for (int i = 0; i < bieuthucs.Length; i++)
            {
                if (LaToanHang(bieuthucs[i]) || bieuthucs[i] == ".")
                {
                    ketqua.Push(bieuthucs[i]);
                    continue;
                }
                else if (bieuthucs[i] == "(")
                {
                    toantu.Push(bieuthucs[i]);
                }
                else if (bieuthucs[i] == ")")
                {
                    while (!toantu.IsEmpty() && (string)toantu.Peek() != "(")
                    {
                        ketqua.Push(toantu.Pop().data);
                    }
                    if (!toantu.IsEmpty() && (string)toantu.Peek() == "(")
                    {
                        toantu.Pop();
                    }
                }
                else
                {
                    while (!toantu.IsEmpty() && Priority((string)toantu.Peek()) >= Priority(bieuthucs[i]))
                    {
                        ketqua.Push(toantu.Pop().data);
                    }
                    toantu.Push(bieuthucs[i]);

                }

            }
            while (!toantu.IsEmpty())
            {
                ketqua.Push(toantu.Pop().data);
            }
            return ketqua;
        }
       /* public static void Print(MyStack stack)
        {
            MyStack tempStack = new MyStack();
            List<string> resultList = new List<string>();

            while (!stack.IsEmpty())
            {
                Node node = stack.Pop();
                if (node != null)
                {
                    resultList.Add(node.ToString());
                    tempStack.Push(node.data);
                }
            }

            while (!tempStack.IsEmpty())
            {
                stack.Push(tempStack.Pop().data);
            }
            resultList.Reverse();
            Console.WriteLine(string.Join(" ", resultList));
        }*/
       //postfix chuyển xong đang là kiểu MyStack
       //stack truyền vào là póstfix
        public static double TinhBieuThuc(MyStack stack)
        {
            //MyStack tempStack = new MyStack();
            List<string> resultList = new List<string>();

            while (!stack.IsEmpty())
            {
                resultList.Add(stack.Pop().data);
            }
            resultList.Reverse();
            MyStack myStack = new MyStack();
            for (int i = 0; i < resultList.Count; i++)
            {
                if (LaToanHang(resultList[i]) || resultList[i] == ".")// kiểm tra xem có phải là số thực không, phải chính xác là số thực để tính toán.
                {
                    myStack.Push(resultList[i]);
                }
                else
                {
                    double afterValue = double.Parse(myStack.Pop().data);
                    double preValue = double.Parse(myStack.Pop().data);



                    switch (resultList[i])
                    {
                        case "+":
                            myStack.Push((afterValue + preValue).ToString());
                            break;
                        case "-":
                            myStack.Push((preValue - afterValue).ToString());
                            break;
                        case "*":
                            myStack.Push((afterValue * preValue).ToString());
                            break;
                        case "/":
                            myStack.Push((preValue / afterValue).ToString());
                            break;
                        default:
                            throw new InvalidOperationException("Toán tử không hợp lệ: "); 

                    }
                }
            }
            return double.Parse(myStack.Pop().data);
        }

       /* private static bool IsOperator(string c)
        {
            return c == "+" || c == "-" || c == "*" || c == "/";
        }*/
        private static int Priority(string op)
        {
            switch (op)
            {
                case "+":
                case "-":
                    return 1;
                case "*":
                case "/":
                    return 2;
                default: return 0;
            }
        }
        private static string[] KhoangTrang(string bieuthucs)
        {
            string number = "";
            foreach (char item in bieuthucs)
            {
                if (char.IsDigit(item) || item == '.') // nếu là số thì thêm vào bth 2*(12+8)/56 
                {
                    number += item;
                }
                else if (item == '(') // nếu là ngoặc mở thì thêm khoảng trắng vào sau ngoặc đó 2_*(_12_+_8)_/_56
                {
                    number += item + " ";
                }
                else if (item == ')') // ngoặc đóng thì ngược lại 
                {
                    number += " " + item;
                }
                else
                {
                    number += " " + item + " "; // nếu là toán tử thì thêm vào string với khoảng trắng trước và sau toán tử 
                }
            }
            string[] result = number.Split(' ');
            return result;
        }
        private static bool LaToanHang(string item)
        {
            if (double.TryParse(item, out double item1)) // nếu là 1 số 
            {
                return true;
            }
            return false;
        }
    }
}