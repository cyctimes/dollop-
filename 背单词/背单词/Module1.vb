Module Module1

    Sub Main()
        Dim WordList As String = CurDir() & "\List.txt"
        Dim Request As Integer
        Dim Word As String
        Dim Def As String
        Dim DWord As String
        Dim DDef As String
        Dim Score As Integer
        Dim Incorrect As Integer
        Dim Practice As Integer


        Console.WriteLine("欢迎使用Dollop")
        Console.WriteLine("1：录入单词 2：练习单词 3：测试 4:退出 5：清除数据")
        Request = Console.ReadLine
        If Request = 1 Then
            FileOpen(1, WordList, OpenMode.Append)
            Do
                Console.WriteLine("请输入单词（退出按X）：")
                Word = Console.ReadLine
                If Word = "x" Or Word = "X" Then
                    Exit Do
                End If
                WriteLine(1, Word)
                Console.WriteLine("请输入单词释义：")
                Def = Console.ReadLine
                WriteLine(1, Def)
            Loop
            FileClose(1)
            Console.WriteLine("正在载入数据...")
        ElseIf Request = 2 Then
            FileOpen(1, WordList, OpenMode.Input)
            Console.WriteLine("正在准备练习...")
            Console.WriteLine("1：练习单词 2：练习释义")
            Practice = Console.ReadLine
            If Practice = 1 Then
                Word = LineInput(1)
                Def = LineInput(1)
                Console.WriteLine("这个单词什么意思？" & Word)
                DWord = Console.ReadLine
                If Word = DWord Then
                    Console.WriteLine("答对了！")
                    Score += 1
                Else
                    Console.WriteLine("答错了！")
                    Incorrect += 1
                End If
            ElseIf Practice = 2 Then
                Do While Not EOF(1)
                    Word = LineInput(1)
                    Def = LineInput(1)
                    Console.WriteLine("对应的是什么词？" & Def)
                    DDef = Console.ReadLine
                    If Def = DDef Then
                        Console.WriteLine("答对了！")
                        Score += 1
                    Else
                        Console.WriteLine("答错了！")
                    End If
                Loop
            End If
            Console.WriteLine("练习结束！")
            Console.WriteLine("你的成绩：")
            Console.WriteLine("正确题目：" & Score)
            Console.WriteLine("错误题目：" & Incorrect)

        ElseIf Request = 3 Then
            Console.WriteLine("该功能还在开发中...敬请期待！")
        ElseIf Request = 4 Then
            Console.WriteLine("按任意键退出！")
        ElseIf Request = 5 Then
            Console.WriteLine("正在清除数据...")
            FileOpen(1, WordList, OpenMode.Output)
            FileClose(1)
            Incorrect = 0
            Score = 0
            Console.WriteLine("清除成功!")
        Else
            Console.WriteLine("错误！")
        End If
        Console.ReadLine()
    End Sub

End Module
