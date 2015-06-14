@modeltype String

@If Not String.IsNullOrEmpty(Model) Then
    @<div class="cmt-title margin-top">
        <i class=" icon-cog icon-white"></i>&nbsp;Quảng Cáo
    </div>
    @<div style="padding-top: 10px;">
        @Html.Raw(Model)
    </div>
End If