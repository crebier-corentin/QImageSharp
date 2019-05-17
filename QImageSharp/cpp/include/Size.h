#ifndef QIMAGESHARP_SIZE_H
#define QIMAGESHARP_SIZE_H

#include <QSize>
#include "global.h"

extern "C" {

QIMAGESHARP_EXPORT QSize *QSizeBoundedTo(QSize *qSize, QSize otherSize);
QIMAGESHARP_EXPORT QSize *QSizeExpandedTo(QSize *qSize, QSize otherSize);

QIMAGESHARP_EXPORT void QSizeScale(QSize *qSize, int width, int height, Qt::AspectRatioMode mode);
QIMAGESHARP_EXPORT QSize *QSizeScaled(QSize qSize, int width, int height, Qt::AspectRatioMode mode);


};

#endif //QIMAGESHARP_SIZE_H
