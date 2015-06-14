Public Class ProductDetailViewModel

#Region "Private members"

    Private context As siteEntities

#End Region

#Region "Constructors"

    Public Sub New()
        context = New siteEntities
        context.Configuration.LazyLoadingEnabled = False
    End Sub

#End Region

#Region "Properties"

    Public Property MenuLevel1List As SelectList

    Public Property MenuLevel2List As SelectList

    Public Property Product As Product

    Public Property Command As Constants.Command

#End Region

#Region "Methods"

    Public Sub Init(id As Integer)
        If id = 0 Then
            Me.MenuLevel1List = New SelectList(Me.context.Categories, "Id", "Name")
            Me.MenuLevel2List = New SelectList(Me.context.Makers, "Id", "Name")
            Me.Command = Constants.Command.AddNew
            Me.Product = New Product
            Me.Product.Id = 0
            Me.Product.OldPrice = 0
            Me.Product.NewPrice = 0
        Else
            Me.GetProduct(id)
            Me.Command = Constants.Command.Update
            If Me.Product IsNot Nothing Then
                Me.MenuLevel1List = New SelectList(Me.context.Categories, "Id", "Name", Me.Product.CategoryId)
                Me.MenuLevel2List = New SelectList(Me.context.Makers, "Id", "Name", Me.Product.MakerId)                
            Else
                Me.Product = New Product
            End If
        End If
    End Sub

    Public Sub InitForError()
        Me.MenuLevel1List = New SelectList(Me.context.Categories, "Id", "Name", Me.Product.CategoryId)
        Me.MenuLevel2List = New SelectList(Me.context.Makers, "Id", "Name", Me.Product.MakerId)
    End Sub

    Public Sub GetProduct(id As Integer)
        Me.Product = context.Products.Find(id)
    End Sub

    Public Sub DeleteProduct()
        Dim item = context.Products.Find(Product.Id)
        If item IsNot Nothing Then
            context.Products.Remove(item)
            context.SaveChanges()
        End If        
    End Sub

    Public Sub UpdateProduct()
        Dim dat As Date = Date.Now
        Me.Product.UdDate = dat
        Select Case Me.Command
            Case Constants.Command.AddNew
                Me.Product.AdDate = dat                
                context.Entry(Me.Product).State = EntityState.Added
            Case Constants.Command.Update
                Dim item = context.Products.Find(Product.Id)
                If item Is Nothing Then
                    Me.Product.AdDate = dat
                    context.Entry(Me.Product).State = EntityState.Added
                Else
                    context.Entry(item).CurrentValues.SetValues(Me.Product)
                End If                
        End Select
        context.SaveChanges()
    End Sub

    Public Function CheckLink() As String
        Dim errorMsg As String = String.Empty
        Dim link As String = SharedFunc.CreateLink(Me.Product.Name)
        If link <> String.Empty Then
            Dim item As Product = context.Products.Where(Function(x) x.Link = link).FirstOrDefault
            If item IsNot Nothing Then
                If item.Id <> Me.Product.Id Then
                    errorMsg = "Tên bạn nhập đã tồn tại. Vui lòng nhập tên khác."
                End If
                context.Entry(item).State = EntityState.Detached
            End If
        Else
            errorMsg = "Tên bạn nhập không hợp lệ. Vui lòng nhập tên khác."
        End If
        Me.Product.Link = link
        Return errorMsg
    End Function

#End Region


End Class