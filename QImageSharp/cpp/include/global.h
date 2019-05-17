#ifndef QIMAGESHARP_GLOBAL_H
#define QIMAGESHARP_GLOBAL_H

#if defined(QIMAGESHARP_LIBRARY)
#define QIMAGESHARP_EXPORT __declspec(dllexport)
#else
#define QIMAGESHARP_EXPORT __declspec(dllimport)
#endif

#endif //QIMAGESHARP_GLOBAL_H
