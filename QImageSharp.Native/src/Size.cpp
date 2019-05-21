#include "Size.h"

QSize *QSizeBoundedTo(QSize *qSize, QSize otherSize) {
    return new QSize(qSize->boundedTo(otherSize));
}

QSize *QSizeExpandedTo(QSize *qSize, QSize otherSize) {
    return new QSize(qSize->expandedTo(otherSize));
}


void QSizeScale(QSize *qSize, int width, int height, Qt::AspectRatioMode mode) {
    qSize->scale(width, height, mode);
}

QSize *QSizeScaled(QSize qSize, int width, int height, Qt::AspectRatioMode mode) {
    return new QSize(qSize.scaled(width, height, mode));
}