cmake_minimum_required(VERSION 3.10)
include(GNUInstallDirs)

project(QImageSharpNative VERSION 0.1.0)

set(CMAKE_CXX_STANDARD 11)

find_package(Qt5 COMPONENTS Gui REQUIRED)

set(SOURCE_FILES src/Color.cpp src/Point.cpp src/Size.cpp)
set(HEADER_FILES include/global.h include/Color.h include/Point.h include/Size.h)

add_library(QImageSharpNative MODULE ${SOURCE_FILES})
target_include_directories(QImageSharpNative PRIVATE "include")
target_link_libraries(QImageSharpNative PRIVATE Qt5::Gui)
target_compile_definitions(QImageSharpNative PRIVATE "QIMAGESHARP_LIBRARY")

#Mt
if (MSVC)
    if (CMAKE_BUILD_TYPE STREQUAL "Debug")
        target_compile_options(QImageSharpNative PRIVATE "/MTd")
    else ()
        target_compile_options(QImageSharpNative PRIVATE "/MT")
    endif ()
endif ()

#Os
if (CMAKE_SYSTEM_NAME STREQUAL "Windows")
    set(QImageSharpNative_LIB_NAME "QImageSharpNative.dll")
    set(QImageSharpNative_NUGET_ID "QImageSharp.Native.Windows")

elseif (CMAKE_SYSTEM_NAME STREQUAL "Linux")
    set(QImageSharpNative_LIB_NAME "libQImageSharpNative.dll")
    set(QImageSharpNative_NUGET_ID "QImageSharp.Native.Linux")

elseif (CMAKE_SYSTEM_NAME STREQUAL "Darwin")
    set(QImageSharpNative_LIB_NAME "libQImageSharpNative.dylib")
    set(QImageSharpNative_NUGET_ID "QImageSharp.Native.OSX")

endif ()

set_target_properties(QImageSharpNative PROPERTIES PREFIX "")
set_target_properties(QImageSharpNative PROPERTIES OUTPUT_NAME ${QImageSharpNative_LIB_NAME})
set_target_properties(QImageSharpNative PROPERTIES SUFFIX "")

#Nuget files
configure_file("${CMAKE_CURRENT_SOURCE_DIR}/QImageSharp.Native.nuspec.in" "${CMAKE_CURRENT_SOURCE_DIR}/${QImageSharpNative_NUGET_ID}.nuspec" @ONLY)
configure_file("${CMAKE_CURRENT_SOURCE_DIR}/QImageSharp.Native.targets.in" "${CMAKE_CURRENT_SOURCE_DIR}/${QImageSharpNative_NUGET_ID}.targets" @ONLY)

#Install
set(CMAKE_INSTALL_PREFIX "${CMAKE_CURRENT_SOURCE_DIR}/build")

install(TARGETS QImageSharpNative
        RUNTIME DESTINATION ${CMAKE_INSTALL_BINDIR}
        LIBRARY DESTINATION ${CMAKE_INSTALL_LIBDIR}
        )

