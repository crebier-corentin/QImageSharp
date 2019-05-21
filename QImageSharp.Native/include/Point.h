#include <QPoint>
#include "global.h"

extern "C" {

QIMAGESHARP_EXPORT int QPointManhattanLength(QPoint *qPoint);
QIMAGESHARP_EXPORT int QPointDotProduct(QPoint* qPoint1, QPoint* qPoint2);

}