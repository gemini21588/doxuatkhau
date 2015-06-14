Public Class MenuLevelViewModel

    Private context As siteEntities

#Region "Constructors"
    Public Sub New()
        context = New siteEntities
        context.Configuration.LazyLoadingEnabled = False
    End Sub
#End Region

#Region "Properties"

    Public Property MenuLevelList As List(Of MenuLevelModel)

    Public Property MenuName As String

    Public Property Level As Integer

    Public Property Name As String

    Public Property Id As String

    Public Property ErrorMsg As String = String.Empty

    Public Property IsUsing As Boolean

#End Region

    Public Sub GetMenuLevel(level As Integer)
        Me.Level = level

        Select Case level
            Case Constants.MenuLevel.Category
                Me.MenuLevelList = context.Categories.Select(Function(x) New MenuLevelModel With {.Id = x.Id, .Name = x.Name, .Link = x.Link}).ToList()
                Me.MenuName = Constants.MenuLevelName.MenuLevel1
            Case Constants.MenuLevel.Maker
                Me.MenuLevelList = context.Makers.Select(Function(x) New MenuLevelModel With {.Id = x.Id, .Name = x.Name, .Link = x.Link}).ToList()
                Me.MenuName = Constants.MenuLevelName.MenuLevel2
        End Select
    End Sub

    Public Sub AddMenu(model As MenuLevelModel)
        Dim link As String = SharedFunc.CreateLink(model.Name)
        If link.Length > 0 Then
            Dim isExist As Boolean = False
            Select Case model.Level
                Case Constants.MenuLevel.Category '' menu cấp 1
                    Dim menu As Category = context.Categories.Where(Function(x) x.Link = link).FirstOrDefault()

                    Dim dat As Date = Date.Now()
                    Dim newCategory As New Category With {
                        .Id = model.Id,
                        .Name = model.Name.Trim(),
                        .Link = link,
                        .UdDate = dat
                        }

                    If menu Is Nothing Then
                        If model.Id = 0 Then
                            newCategory.AdDate = dat
                            context.Categories.Add(newCategory)
                        Else
                            Dim item = context.Categories.Find(model.Id)
                            If item Is Nothing Then
                                newCategory.AdDate = dat
                                context.Categories.Add(newCategory)
                            Else
                                context.Entry(item).CurrentValues.SetValues(newCategory)
                            End If                            
                        End If
                        context.SaveChanges()
                    Else
                        If model.Id <> menu.Id Then
                            isExist = True
                        End If
                    End If

                Case Constants.MenuLevel.Maker '' menu cấp 2
                    Dim menu As Maker = context.Makers.Where(Function(x) x.Link = link).FirstOrDefault()

                    Dim dat As Date = Date.Now()
                    Dim newMaker As New Maker With {
                        .Id = model.Id,
                        .Name = model.Name.Trim(),
                        .Link = link,
                        .UdDate = dat
                        }

                    If menu Is Nothing Then
                        If model.Id = 0 Then
                            newMaker.AdDate = dat
                            context.Makers.Add(newMaker)
                        Else
                            Dim item = context.Makers.Find(model.Id)
                            If item Is Nothing Then
                                newMaker.AdDate = dat
                                context.Makers.Add(newMaker)
                            Else
                                context.Entry(item).CurrentValues.SetValues(newMaker)
                            End If                            
                        End If
                        context.SaveChanges()
                    Else
                        If model.Id <> menu.Id Then
                            isExist = True
                        End If
                    End If
            End Select

            '' Trường hợp link đã tồn tại thì hiển thị message error
            If isExist Then
                Me.ErrorMsg = "Tên bạn nhập đã tồn tại. Vui lòng nhập tên khác."
                Me.Name = model.Name
                Me.Id = model.Id
            End If
        Else
            Me.ErrorMsg = "Tên bạn nhập không hợp lệ. Vui lòng nhập tên khác."
            Me.Name = model.Name
            Me.Id = model.Id
        End If
    End Sub

    Public Sub DeleteMenuLevel(model As MenuLevelModel)
        Select Case model.Level
            Case Constants.MenuLevel.Category
                Dim item = context.Categories.Find(model.Id)
                If item IsNot Nothing Then
                    Me.IsUsing = IsMenuLevelUsing(model)
                    If Not Me.IsUsing Then
                        context.Categories.Remove(item)
                        context.SaveChanges()
                    End If
                End If                

            Case Constants.MenuLevel.Maker
                Dim item = context.Makers.Find(model.Id)
                If item IsNot Nothing Then
                    Me.IsUsing = IsMenuLevelUsing(model)
                    If Not Me.IsUsing Then
                        context.Makers.Remove(item)
                        context.SaveChanges()
                    End If
                End If                
        End Select
    End Sub

    Private Function IsMenuLevelUsing(model As MenuLevelModel)
        Dim isUsing As Boolean = False

        Select Case model.Level
            Case Constants.MenuLevel.Category
                Dim count As Integer
                count = context.Products.Count(Function(x) x.CategoryId = model.Id)
                If count > 0 Then
                    isUsing = True
                End If

            Case Constants.MenuLevel.Maker
                Dim count As Integer
                count = context.Products.Count(Function(x) x.MakerId = model.Id)
                If count > 0 Then
                    isUsing = True
                End If
        End Select

        Return isUsing
    End Function
End Class
