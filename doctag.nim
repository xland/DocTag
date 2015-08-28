import windows,everything_lib
var str = newWideCString("doctag.nim")
Everything_SetSearchW(str)
discard Everything_QueryW(1)
var rowsNum = Everything_GetNumResults()
for i in 0..rowsNum-1:
    var name = Everything_GetResultFileNameW(i) 
    echo( $name )
echo("ok")