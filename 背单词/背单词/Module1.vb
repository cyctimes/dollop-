Module Module1

    Sub Main()
        Dim WordList As String = CurDir() & "\Word list.txt"
        Dim Read As Integer
        Dim Word As String
        Dim Def As String
        Dim Practice As String
        Dim Score As Integer
        Dim Mode As Integer
        Dim Correct As Integer
        Dim Incorrect As Integer
        Dim Clear As Char
        Dim File As String

        Console.WriteLine("欢迎使用背单词！")
        Console.WriteLine("1: 录入单词 2：练习单词 3:退出 4：清理")
        Read = Console.ReadLine
        If Read = 1 Then
            Do
                Console.WriteLine("请输入单词！退出请按：x，按任意键退出！")
                Word = Console.ReadLine
                If Word = "x" Or Word = "X" Then
                    Exit Do
                End If
                If Word = "" Then
                    Console.WriteLine("你还没有输入单词！")
                    Console.Write("重新输入！")
                End If
                Console.WriteLine("请输入单词释义：")
                Def = Console.ReadLine
                FileOpen(1, WordList, OpenMode.Append)
                WriteLine(1, Word)
                WriteLine(1, Def)
                FileClose(1)
            Loop
        ElseIf Read = 2 Then
            Console.WriteLine("你即将开始练习单词！一个单词一分！")
            Console.WriteLine("你想怎么练习？【1：练习释义；2：练习词汇】")
            Mode = Console.ReadLine
            If Mode = 1 Then
                ' 练习释义
                FileOpen(1, WordList, OpenMode.Input)
                File = System.IO.File.ReadAllText(WordList)
                If File.Length = 0 Then
                    Console.WriteLine("请检查文件正确性！")
                Else

                    Do Until Not EOF(1)
                        Word = LineInput(1)
                        Def = LineInput(1)
                        Console.WriteLine("对应的单词是什么？" & Def)
                        Practice = Console.ReadLine
                        If Practice <> Word Then
                            Console.WriteLine("不对哦！")
                            Incorrect += 1
                        Else
                            Console.WriteLine("正确！")
                            Score += 1
                            Correct += 1
                        End If
                    Loop
                End If
                FileClose(1)
            ElseIf Mode = 2 Then
                ' 练习词汇
                FileOpen(1, WordList, OpenMode.Input)
                '检查文件正确性
                File = System.IO.File.ReadAllText(WordList)
                If File.length = 0 Then
                    Console.WriteLine("请检查文件正确性！")
                Else
                    Do Until Not EOF(1)
                        Word = LineInput(1)
                        Def = LineInput(1)
                        Console.WriteLine(Word & " 是什么意思？")
                        Practice = Console.ReadLine
                        If Practice <> Def Then
                            Console.WriteLine("不对哦！")
                            Incorrect += 1
                        Else
                            Console.WriteLine("正确！")
                            Score += 1
                            Correct += 1
                        End If
                    Loop
                    FileClose(1)
                End If
            ElseIf Mode = "" Or Mode = " " Then
                Console.WriteLine("你是不是输错了什么？")
            End If
            ' 完成练习
            Console.WriteLine("恭喜你！你完成了练习！")
            Console.WriteLine("你的分数：" & Score)
            Console.WriteLine("你对了：" & Correct & " 道题")
            Console.WriteLine("你错了：" & Incorrect & " 道题")
        ElseIf Read = 3 Then
            Console.WriteLine("按任意键退出！")
        ElseIf Read = 4 Then
            Console.WriteLine("你确定清零吗？[Y/N]")
            Clear = Console.ReadLine
            If Clear = "y" Or Clear = "Y" Then
                Console.WriteLine("正在清零...")
                FileOpen(1, WordList, OpenMode.Output)
                FileClose(1)
                Console.WriteLine("清零成功！")
            End If
        Else
            Console.WriteLine("你输错了！按任意键退出！")
        End If

        Console.ReadLine()
    End Sub

End Module
