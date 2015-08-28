import windows,everything_lib
var str = newWideCString("doctag.nim")
var lpcstr = cast[LPCWSTR](addr str[0])
Everything_SetSearchW(lpcstr)
discard Everything_QueryW(1)
var rowsNum = Everything_GetNumResults()
for i in 0..rowsNum-1:
    var name = Everything_GetResultFileNameW(i) 
    var nameStr = $cast[WideCString](name)
    echo( nameStr )
echo("ok")