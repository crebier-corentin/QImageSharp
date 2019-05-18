#ifndef QIMAGESHARP_COLOR_H
#define QIMAGESHARP_COLOR_H

#include <QColor>
#include "global.h"

extern "C" {

QIMAGESHARP_EXPORT QColor *CreateQColor();
QIMAGESHARP_EXPORT QColor *CreateQColorRgb(int r, int g, int b, int a = 255);
QIMAGESHARP_EXPORT QColor *CreateQColorCmyk(int c, int m, int y, int k, int a = 255);
QIMAGESHARP_EXPORT QColor *CreateQColorHsl(int h, int s, int l, int a = 255);

QIMAGESHARP_EXPORT void FreeQColor(QColor *qColor);

//Spec
QIMAGESHARP_EXPORT QColor::Spec QColorSpec(QColor *qColor);
QIMAGESHARP_EXPORT QColor *QColorConvertTo(QColor *qColor, QColor::Spec spec);

//Alpha
QIMAGESHARP_EXPORT int QColorAlpha(QColor *qColor);
QIMAGESHARP_EXPORT void QColorSetAlpha(QColor *qColor, int value);

//Get RGB
QIMAGESHARP_EXPORT int QColorRed(QColor *qColor);
QIMAGESHARP_EXPORT int QColorGreen(QColor *qColor);
QIMAGESHARP_EXPORT int QColorBlue(QColor *qColor);

//Set RGB
QIMAGESHARP_EXPORT void QColorSetRed(QColor *qColor, int value);
QIMAGESHARP_EXPORT void QColorSetGreen(QColor *qColor, int value);
QIMAGESHARP_EXPORT void QColorSetBlue(QColor *qColor, int value);

QIMAGESHARP_EXPORT void QColorSetRgb(QColor *qColor, int r, int g, int b, int a = 255);

//HSL
QIMAGESHARP_EXPORT int QColorHslHue(QColor *qColor);
QIMAGESHARP_EXPORT int QColorHslSaturation(QColor *qColor);
QIMAGESHARP_EXPORT int QColorLightness(QColor *qColor);

QIMAGESHARP_EXPORT void QColorSetHsl(QColor *qColor, int h, int s, int l, int a = 255);

//CMYK
QIMAGESHARP_EXPORT int QColorCyan(QColor *qColor);
QIMAGESHARP_EXPORT int QColorMagenta(QColor *qColor);
QIMAGESHARP_EXPORT int QColorYellow(QColor *qColor);
QIMAGESHARP_EXPORT int QColorBlack(QColor *qColor);

QIMAGESHARP_EXPORT void QColorSetCymk(QColor *qColor, int c, int m, int y, int k, int a = 255);


}
#endif //QIMAGESHARP_COLOR_H
