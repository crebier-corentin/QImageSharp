cmake_minimum_required(VERSION 3.10)
include(GNUInstallDirs)

project(QImageSharpNative)

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

#Install
set(CMAKE_INSTALL_PREFIX "${CMAKE_CURRENT_SOURCE_DIR}/build")

install(TARGETS QImageSharpNative
        RUNTIME DESTINATION ${CMAKE_INSTALL_BINDIR}
        LIBRARY DESTINATION ${CMAKE_INSTALL_LIBDIR}
        )
install(FILES ${HEADER_FILES} DESTINATION ${CMAKE_INSTALL_INCLUDEDIR})
