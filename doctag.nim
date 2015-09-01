import  windows,strutils,tables,iup,db_sqlite

#定义一些全局的变量
var tagTextBox,tagsContainer,searchFileContainer,allTagsContainer,curFileTagsContainer:PIhandle ##窗口上的控件句柄
var tagsTable = initTable[int,PIhandle]() ##这里存放当前文档的所有标签的控件句柄
var targetPath,targetName:string ##当前文件的路径，当前文件的文件名
var conn:TDbConn = db_sqlite.open("db.db","","","")##打开数据库链接

proc TagItBtnClick(arg: PIhandle): cint {.cdecl.} =
    ##点击一个标签控件的时候，触发此函数
    var sqlStr = sql("insert into Tag (Tag) values (?)")
    var  val = tagTextBox.getAttribute("VALUE")
    conn.exec(sqlStr,val)
    message("Hello World Message", val)
    
proc showCurDocTags()=    
    ##在窗口上显示当前文件的所有标签
    var rows = conn.getAllRows(sql"select * from Tag")
    for i in 0 .. rows.len-1:
        var tag = iup.link("http://nim-lang.org/",$rows[i][1])
        tagsTable[rows[i][0].parseInt] = tag
        discard tagsContainer.insert(nil,tag)

proc appInit() =
    ##系统初始化
    iup.storeGlobal("UTF8MODE", "YES")#不这么干会出现乱码
    discard iup.open(nil, nil)
    var params = windows.GetCommandLineA()#右键选中的那个文件或者文件夹是从命令行传过来的，todo:选择了多个文件的时候，会打开多个实例
    targetPath = $cast[cstring](params)
    targetPath = targetPath.subStr(targetPath.find(" "))
    targetName = targetPath.subStr(targetPath.rfind("\\")+1)

proc drawSearchFileTab()=
    ##搜索文件选项卡
    searchFileContainer = iup.vbox(iup.fill(),nil)
    searchFileContainer.setAttribute("TABTITLE","文件查找")

proc drawAllTagTab()=
    ##所有标签选项卡
    var tag1 = iup.link("http://nim-lang.org/","我的标签")
    allTagsContainer = iup.vbox(tag1,iup.fill(),nil)
    allTagsContainer.setAttribute("TABTITLE","所有标签")

proc drawCurFileTagTab()=
    ##当前文档选项卡
    var label = iup.label("当前文件："&targetName)
    discard label.setAttributes("MARGIN=6X6")
    tagTextBox = iup.text(nil)
    discard tagTextBox.setAttributes("EXPAND=HORIZONTAL,SIZE=x12")
    var tagButton = iup.button("打标签",nil)
    tagButton.setCallback("ACTION", cast[Icallback](TagItBtnClick))
    discard tagButton.setAttributes("SIZE=56X")
    var tagItContainer = iup.hbox(tagTextBox,tagButton,nil)
    discard tagItContainer.setAttributes("GAP=4,MARGIN=0X4X4X4")
    tagsContainer = iup.hbox(iup.fill(),nil)
    discard tagsContainer.setAttributes("MARGIN=0X4X4X4,GAP=4")
    curFileTagsContainer = iup.vbox(label,tagItContainer,tagsContainer,iup.fill(),nil)
    curFileTagsContainer.setAttribute("TABTITLE","打标签")
    showCurDocTags()

    
proc drawDialog()=
    ##系统窗口
    var tabs = iup.tabs(curFileTagsContainer,allTagsContainer,searchFileContainer,nil)
    var tabsContainer = iup.vbox(tabs,nil)
    tabs.setAttribute("EXPAND","YES")
    tabsContainer.setAttribute("MARGIN","6x6")
    var dlg = iup.dialog(tabsContainer)
    dlg.setAttribute("TITLE", "文件-标签") #todo
    dlg.setAttribute("SIZE", "QUARTERxQUARTER")
    discard dlg.showXY(IUP_CENTER, IUP_CENTER)
    dlg.setAttribute("USERSIZE",nil)
    
appInit()
drawSearchFileTab()
drawAllTagTab()
drawCurFileTagTab()
drawDialog()

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