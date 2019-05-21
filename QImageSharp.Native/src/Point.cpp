#include "Point.h"

int QPointManhattanLength(QPoint *qPoint) {
    return qPoint->manhattanLength();
}

int QPointDotProduct(QPoint *qPoint1, QPoint *qPoint2) {
    return QPoint::dotProduct(*qPoint1, *qPoint2);
}
