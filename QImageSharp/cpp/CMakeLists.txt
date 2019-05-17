cmake_minimum_required(VERSION 3.11)
include(GNUInstallDirs)

project(QImageSharpNative)

set(CMAKE_CXX_STANDARD 11)

find_package(Qt5 COMPONENTS Gui REQUIRED)

set(SOURCE_FILES src/Color.cpp src/Point.cpp src/Size.cpp)
set(HEADER_FILES include/global.h include/Color.h include/Point.h include/Size.h)

add_library(QImageSharpNative SHARED ${SOURCE_FILES})
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
    set(RID_PlATFORM "win")
elseif (CMAKE_SYSTEM_NAME STREQUAL "Linux")
    set(RID_PlATFORM "linux")
elseif (CMAKE_SYSTEM_NAME STREQUAL "Darwin")
    set(RID_PlATFORM "osx")
endif ()


#32 or 64 Name
if (CMAKE_SIZEOF_VOID_P EQUAL 8)
    # 64 bits
    set(RID_ARCH "x64")
elseif (CMAKE_SIZEOF_VOID_P EQUAL 4)
    # 32 bits
    set(RID_ARCH "x86")
endif ()

set_target_properties(QImageSharpNative PROPERTIES OUTPUT_NAME "QImageSharpNative-${RID_PlATFORM}-${RID_ARCH}")

#Install
set(CMAKE_INSTALL_PREFIX "${CMAKE_CURRENT_SOURCE_DIR}/build")

install(TARGETS QImageSharpNative)
install(FILES ${HEADER_FILES} DESTINATION ${CMAKE_INSTALL_INCLUDEDIR})
