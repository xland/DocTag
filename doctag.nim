import  windows,strutils,iup
discard iup.open(nil, nil)

#读取当前选中的文件
var params = windows.GetCommandLineA()
var targetPath = $cast[cstring](params)
targetPath = targetPath.subStr(targetPath.find(" "))
var targetName = targetPath.subStr(targetPath.rfind("\\")+1)
echo(targetPath)
echo(targetName)
#todo:选择了多个文件的时候，会打开多个实例

#search files
var searchFileContainer = iup.vbox(iup.fill(),nil)
searchFileContainer.setAttribute("TABTITLE","文件查找")

#all tags tab
var tag1 = iup.link("http://nim-lang.org/","我的标签")
var allTagsContainer = iup.vbox(tag1,iup.fill(),nil)
allTagsContainer.setAttribute("TABTITLE","所有标签")
#cur file tags tab
var label = iup.label("当前文件："&targetName)
discard label.setAttributes("MARGIN=6X6")
var tagTextBox = iup.text(nil)
discard tagTextBox.setAttributes("EXPAND=HORIZONTAL,SIZE=x12")
var tagButton = iup.button("打标签",nil)
discard tagButton.setAttributes("SIZE=56X")
var tagItContainer = iup.hbox(tagTextBox,tagButton,nil)
discard tagItContainer.setAttributes("GAP=4,MARGIN=0X4X4X4")

var tag = iup.link("http://nim-lang.org/","我的标签")
var tagsContainer = iup.hbox(tag,iup.fill(),nil)
discard tagsContainer.setAttributes("MARGIN=0X4X4X4")

var curFileTagsContainer = iup.vbox(label,tagItContainer,tagsContainer,iup.fill(),nil)
curFileTagsContainer.setAttribute("TABTITLE","打标签")
#tabs
var tabs = iup.tabs(curFileTagsContainer,allTagsContainer,searchFileContainer,nil)
var tabsContainer = iup.vbox(tabs,nil)
tabs.setAttribute("EXPAND","YES")
tabsContainer.setAttribute("MARGIN","6x6")
#dialog
var dlg = iup.dialog(tabsContainer)
dlg.setAttribute("TITLE", "文件-标签") #todo
dlg.setAttribute("SIZE", "QUARTERxQUARTER")
discard dlg.showXY(IUP_CENTER, IUP_CENTER)
dlg.setAttribute("USERSIZE",nil)
discard mainLoop()
close()


#   var vbox = iup.vbox(cbox)
#   vbox.setAttribute("TABTITLE","CESHI测试中文")
#
#
#   var tabs = iup.frame(nil)
#   tabs.setAttribute("EXPAND","YES")
#   tabs.setAttribute("TITLE","YES")
#
#   var fbox = iup.hbox(tabs,nil)
#   fbox.setAttribute("EXPAND","YES")

#import windows,everything_lib
#var str = newWideCString("doctag.nim")
#Everything_SetSearchW(str)
#discard Everything_QueryW(1)
#var rowsNum = Everything_GetNumResults()
#for i in 0..rowsNum-1:
#    var name = Everything_GetResultFileNameW(i)     #$cast[WideCString](lpcwstr)
#    echo( $name )
#echo("ok")