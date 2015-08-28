{.deadCodeElim: on.}
{.passL: "Everything32.lib".}
#{.passL: "-lEverything64.lib".}
import windows

type BOOL* = WINBOOL
type UINT* = int32

const 
  EVERYTHING_OK* = 0
  EVERYTHING_ERROR_MEMORY* = 1
  EVERYTHING_ERROR_IPC* = 2
  EVERYTHING_ERROR_REGISTERCLASSEX* = 3
  EVERYTHING_ERROR_CREATEWINDOW* = 4
  EVERYTHING_ERROR_CREATETHREAD* = 5
  EVERYTHING_ERROR_INVALIDINDEX* = 6
  EVERYTHING_ERROR_INVALIDCALL* = 7

# write search state

proc Everything_SetSearchW*(lpString: WideCString ) {.stdcall, 
  importc: "Everything_SetSearchW".}
proc Everything_SetSearchA*(lpString: LPCSTR) {.stdcall, 
  importc: "Everything_SetSearchA".}
proc Everything_SetMatchPath*(bEnable: BOOL) {.stdcall, 
  importc: "Everything_SetMatchPath".}
proc Everything_SetMatchCase*(bEnable: BOOL) {.stdcall, 
  importc: "Everything_SetMatchCase".}
proc Everything_SetMatchWholeWord*(bEnable: BOOL) {.stdcall, 
  importc: "Everything_SetMatchWholeWord".}
proc Everything_SetRegex*(bEnable: BOOL) {.stdcall, 
  importc: "Everything_SetRegex".}
proc Everything_SetMax*(dwMax: DWORD) {.stdcall, importc: "Everything_SetMax".}
proc Everything_SetOffset*(dwOffset: DWORD) {.stdcall, 
  importc: "Everything_SetOffset".}
proc Everything_SetReplyWindow*(hWnd: HWND) {.stdcall, 
  importc: "Everything_SetReplyWindow".}
proc Everything_SetReplyID*(nId: DWORD) {.stdcall, 
  importc: "Everything_SetReplyID".}
# read search state

proc Everything_GetMatchPath*(): BOOL {.stdcall, 
                                      importc: "Everything_GetMatchPath".}
proc Everything_GetMatchCase*(): BOOL {.stdcall, 
                                      importc: "Everything_GetMatchCase".}
proc Everything_GetMatchWholeWord*(): BOOL {.stdcall, 
  importc: "Everything_GetMatchWholeWord".}
proc Everything_GetRegex*(): BOOL {.stdcall, importc: "Everything_GetRegex".}
proc Everything_GetMax*(): DWORD {.stdcall, importc: "Everything_GetMax".}
proc Everything_GetOffset*(): DWORD {.stdcall, importc: "Everything_GetOffset".}
proc Everything_GetSearchA*(): LPCSTR {.stdcall, 
                                      importc: "Everything_GetSearchA".}
proc Everything_GetSearchW*(): WideCString  {.stdcall, 
  importc: "Everything_GetSearchW".}
proc Everything_GetLastError*(): DWORD {.stdcall, 
  importc: "Everything_GetLastError".}
proc Everything_GetReplyWindow*(): HWND {.stdcall, 
  importc: "Everything_GetReplyWindow".}
proc Everything_GetReplyID*(): DWORD {.stdcall, 
                                     importc: "Everything_GetReplyID".}
# execute query

proc Everything_QueryA*(bWait: BOOL): BOOL {.stdcall, 
  importc: "Everything_QueryA".}
proc Everything_QueryW*(bWait: BOOL): BOOL {.stdcall, 
  importc: "Everything_QueryW".}
# query reply

proc Everything_IsQueryReply*(message: UINT; wParam: WPARAM; lParam: LPARAM; 
                            nId: DWORD): BOOL {.stdcall, 
  importc: "Everything_IsQueryReply".}
# write result state

proc Everything_SortResultsByPath*() {.stdcall, 
                                     importc: "Everything_SortResultsByPath".}
# read result state

proc Everything_GetNumFileResults*(): DWORD {.stdcall, 
  importc: "Everything_GetNumFileResults".}
proc Everything_GetNumFolderResults*(): DWORD {.stdcall, 
  importc: "Everything_GetNumFolderResults".}
proc Everything_GetNumResults*(): DWORD {.stdcall, 
  importc: "Everything_GetNumResults".}
proc Everything_GetTotFileResults*(): DWORD {.stdcall, 
  importc: "Everything_GetTotFileResults".}
proc Everything_GetTotFolderResults*(): DWORD {.stdcall, 
  importc: "Everything_GetTotFolderResults".}
proc Everything_GetTotResults*(): DWORD {.stdcall, 
  importc: "Everything_GetTotResults".}
proc Everything_IsVolumeResult*(nIndex: DWORD): BOOL {.stdcall, 
  importc: "Everything_IsVolumeResult".}
proc Everything_IsFolderResult*(nIndex: DWORD): BOOL {.stdcall, 
  importc: "Everything_IsFolderResult".}
proc Everything_IsFileResult*(nIndex: DWORD): BOOL {.stdcall, 
  importc: "Everything_IsFileResult".}
proc Everything_GetResultFileNameW*(nIndex: DWORD): WideCString  {.stdcall, 
  importc: "Everything_GetResultFileNameW".}
proc Everything_GetResultFileNameA*(nIndex: DWORD): LPCSTR {.stdcall, 
  importc: "Everything_GetResultFileNameA".}
proc Everything_GetResultPathW*(nIndex: DWORD): WideCString  {.stdcall, 
  importc: "Everything_GetResultPathW".}
proc Everything_GetResultPathA*(nIndex: DWORD): LPCSTR {.stdcall, 
  importc: "Everything_GetResultPathA".}
proc Everything_GetResultFullPathNameA*(nIndex: DWORD; buf: LPSTR; 
                                      bufsize: DWORD): DWORD {.stdcall, 
  importc: "Everything_GetResultFullPathNameA".}
proc Everything_GetResultFullPathNameW*(nIndex: DWORD; wbuf: LPWSTR; 
                                      wbuf_size_in_wchars: DWORD): DWORD {.
  stdcall, importc: "Everything_GetResultFullPathNameW".}
# reset state and free any allocated memory

proc Everything_Reset*() {.stdcall, importc: "Everything_Reset".}
