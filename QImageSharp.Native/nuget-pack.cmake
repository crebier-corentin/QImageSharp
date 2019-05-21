message(STATUS ${CMAKE_SYSTEM_NAME})
message(STATUS "Packing ${QImageSharpNative_NUGET_ID}.nuspec")

#Nuget command
if (CMAKE_SYSTEM_NAME STREQUAL "Windows")
    set(nuget_cmd "nuget.bat")
    set(nuget_arg1 "pack" )
    set(nuget_arg2 "")

else ()
    set(nuget_cmd "dotnet")
    set(nuget_arg1 "nuget")
    set(nuget_arg2 "pack")

endif ()

execute_process(COMMAND ${nuget_cmd} ${nuget_arg1} ${nuget_arg2} "${QImageSharpNative_NUGET_ID}.nuspec"
        WORKING_DIRECTORY ${QImageSharpNative_DIR}
        RESULT_VARIABLE RESULT
        OUTPUT_FILE nuget-pack-out.txt
        ERROR_FILE nuget-pack-err.txt)

message(STATUS ${RESULT_VARIABLE})