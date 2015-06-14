@ModelType ChoMayTinh.ContentPageViewModel

@Code
    ViewData("Title") = ChoMayTinh.SharedFunc.PageTitle(Model.Content.Title)
End Code

@If Model.Content Is Nothing Then    
    Return
End If

<div id="contentPage">
    @Html.Raw(Model.Content.Content1)
</div>