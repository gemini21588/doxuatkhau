@ModelType ChoMayTinh.PaginationModel

@If Model.NumbersOfPage < 2 Then
    Return
End If

@If Not Model.IsUseURI Then
    
    @<div class="pagination pagination-centered">
        <ul>
            @If Model.CurrentPage = 1 Then
                @<li class="disabled"><span><i class="fa fa-angle-double-left"></i></span></li>
                @<li class="disabled"><span><i class="fa fa-angle-left"></i></span></li>
    Else
                @<li><a href="@Url.Action(Model.Action, Model.Controller, New With {.page = 1})"><i class="fa fa-angle-double-left"></i></a></li>
                @<li><a href="@Url.Action(Model.Action, Model.Controller, New With {.page = Model.CurrentPage - 1})"><i class="fa fa-angle-left"></i></a></li>      
    End If
            @For i As Integer = 1 To Model.NumbersOfPage
                @If i = Model.CurrentPage Then
                    @<li class="active"><span>@i</span></li>            
        Else
                    @<li><a href="@Url.Action(Model.Action, Model.Controller, New With {.page = i})">@i</a></li>            
        End If            
    Next
            @If Model.CurrentPage = Model.NumbersOfPage Then
                @<li class="disabled"><span><i class="fa fa-angle-right"></i></span></li>
                @<li class="disabled"><span><i class="fa fa-angle-double-right"></i></span></li>
    Else
                @<li><a href="@Url.Action(Model.Action, Model.Controller, New With {.page = Model.CurrentPage + 1})"><i class="fa fa-angle-right"></i></a></li>
                @<li><a href="@Url.Action(Model.Action, Model.Controller, New With {.page = Model.NumbersOfPage})"><i class="fa fa-angle-double-right"></i></a></li>
    End If
        </ul>
    </div>
    
Else
    
    @<div class="pagination pagination-centered">
        <ul>
            @If Model.CurrentPage = 1 Then
                @<li class="disabled"><span><i class="fa fa-angle-double-left"></i></span></li>
                @<li class="disabled"><span><i class="fa fa-angle-left"></i></span></li>
    Else
                @<li><a href="@Url.Content(Model.PageURI & "/1")"><i class="fa fa-angle-double-left"></i></a></li>
                @<li><a href="@Url.Content(Model.PageURI & "/" & (Model.CurrentPage - 1))"><i class="fa fa-angle-left"></i></a></li>      
    End If
            @For i As Integer = 1 To Model.NumbersOfPage
                @If i = Model.CurrentPage Then
                    @<li class="active"><span>@i</span></li>            
        Else
                    @<li><a href="@Url.Content(Model.PageURI & "/" & i)">@i</a></li>            
        End If            
    Next
            @If Model.CurrentPage = Model.NumbersOfPage Then
                @<li class="disabled"><span><i class="fa fa-angle-right"></i></span></li>
                @<li class="disabled"><span><i class="fa fa-angle-double-right"></i></span></li>
    Else
                @<li><a href="@Url.Content(Model.PageURI & "/" & (Model.CurrentPage + 1))"><i class="fa fa-angle-right"></i></a></li>
                @<li><a href="@Url.Content(Model.PageURI & "/" & Model.NumbersOfPage)"><i class="fa fa-angle-double-right"></i></a></li>
    End If
        </ul>
    </div>

End If