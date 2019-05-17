#include "Color.h"
#include <QColor>

QColor *createQColor() {
    return new QColor();
}

QColor *createQColorRgb(int r, int g, int b, int a) {
    return new QColor(r, g, b, a);
}

QColor *createQColorCmyk(int c, int m, int y, int k, int a) {
    return new QColor(QColor::fromCmyk(c, m, y, k, a));
}

QColor *createQColorHsl(int h, int s, int l, int a) {
    return new QColor(QColor::fromHsl(h, s, l, a));
}

void freeQColor(QColor *qColor) {
    delete qColor;
}

//Spec
QColor::Spec QColorSpec(QColor *qColor) {
    return qColor->spec();
}

QColor *QColorConvertTo(QColor *qColor, QColor::Spec spec) {
    return new QColor(qColor->convertTo(spec));
}

//Alpha
int QColorAlpha(QColor *qColor) {
    return qColor->alpha();
}

void QColorSetAlpha(QColor *qColor, int value) {
    qColor->setAlpha(value);
}

//RGB
int QColorRed(QColor *qColor) {
    return qColor->red();
}

int QColorGreen(QColor *qColor) {
    return qColor->green();
}

int QColorBlue(QColor *qColor) {
    return qColor->blue();
}

void QColorSetRed(QColor *qColor, int value) {
    qColor->setRed(value);
}

void QColorSetGreen(QColor *qColor, int value) {
    qColor->setGreen(value);
}

void QColorSetBlue(QColor *qColor, int value) {
    qColor->setBlue(value);
}

void QColorSetRgb(QColor *qColor, int r, int g, int b, int a) {
    qColor->setRgb(r, g, b, a);
}

//HSL
int QColorHslHue(QColor *qColor) {
    return qColor->hslHue();
}

int QColorHslSaturation(QColor *qColor) {
    return qColor->hslSaturation();
}

int QColorLightness(QColor *qColor) {
    return qColor->lightness();
}

void QColorSetHsl(QColor *qColor, int h, int s, int l, int a) {
    qColor->setHsl(h, s, l, a);
}

//CMYK
int QColorCyan(QColor *qColor) {
    return qColor->cyan();
}

int QColorMagenta(QColor *qColor) {
    return qColor->magenta();
}

int QColorYellow(QColor *qColor) {
    return qColor->yellow();
}

int QColorBlack(QColor *qColor) {
    return qColor->black();
}

void QColorSetCymk(QColor *qColor, int c, int m, int y, int k, int a) {
    qColor->setCmyk(c, m, y, k, a);
}







