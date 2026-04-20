# Dialog Styling and Customization

## Overview

The Syncfusion Blazor Dialog component provides extensive customization capabilities through CSS classes and properties. This guide demonstrates how to implement comprehensive styling for different Dialog types including Alert dialogs with predefined styles and fully custom dialogs.

## Alert Predefined Dialog Customization

Alert dialogs can be extensively customized using the `CssClass` property in the `DialogOptions` parameter. The sample demonstrates customization for Info, Success, Warning, Error, and Custom Dialog types.

### How to Customize the Header

The Dialog header can be customized with gradient backgrounds, borders, shadows, and typography. This section appears at the top of the Dialog and typically contains the title and close button.

**Code Snippet:**
```css
.info-dialog .e-dlg-header-content {
    background: linear-gradient(135deg, #667eea 0%, #764ba2 100%) !important;
    border-bottom: 3px solid #5a67d8 !important;
    padding: 16px 20px !important;
}

.info-dialog .e-dlg-header-content .e-dlg-header {
    color: white !important;
    font-weight: 700 !important;
    font-size: 16px !important;
    text-shadow: 1px 1px 2px rgba(0,0,0,0.2) !important;
}
```

**Success Dialog Header:**
```css
.success-dialog .e-dlg-header-content {
    background: linear-gradient(135deg, #11998e 0%, #38ef7d 100%) !important;
    border-bottom: 3px solid #0f9d58 !important;
    padding: 16px 20px !important;
}

.success-dialog .e-dlg-header-content .e-dlg-header {
    color: white !important;
    font-weight: 700 !important;
    font-size: 16px !important;
}
```

**Warning Dialog Header:**
```css
.warning-dialog .e-dlg-header-content {
    background: linear-gradient(135deg, #f093fb 0%, #f5576c 100%) !important;
    border-bottom: 3px solid #ed8936 !important;
    padding: 16px 20px !important;
}

.warning-dialog .e-dlg-header-content .e-dlg-header {
    color: white !important;
    font-weight: 700 !important;
    font-size: 16px !important;
}
```

**Error Dialog Header:**
```css
.error-dialog .e-dlg-header-content {
    background: linear-gradient(135deg, #eb3349 0%, #f45c43 100%) !important;
    border-bottom: 3px solid #c53030 !important;
    padding: 16px 20px !important;
}

.error-dialog .e-dlg-header-content .e-dlg-header {
    color: white !important;
    font-weight: 700 !important;
    font-size: 16px !important;
}
```

---

### Header Close Button

The header close button (`e-icon-btn`) can be customized with transparent backgrounds, rounded shapes, and interactive hover effects. The button supports smooth transitions and transform animations.

**Code Snippet:**
```css
.info-dialog .e-dlg-header-content .e-btn.e-icon-btn {
    background: rgba(255, 255, 255, 0.2) !important;
    color: white !important;
    border: none !important;
    width: 32px !important;
    height: 32px !important;
    border-radius: 50% !important;
}

.info-dialog .e-dlg-header-content .e-btn.e-icon-btn:hover {
    background: rgba(255, 255, 255, 0.4) !important;
    transform: rotate(90deg) !important;
}
```

**Success Dialog Close Button:**
```css
.success-dialog .e-dlg-header-content .e-btn.e-icon-btn {
    background: rgba(255, 255, 255, 0.2) !important;
    color: white !important;
    border-radius: 50% !important;
}

.success-dialog .e-dlg-header-content .e-btn.e-icon-btn:hover {
    background: rgba(255, 255, 255, 0.4) !important;
    transform: rotate(90deg) !important;
}
```

**Warning Dialog Close Button:**
```css
.warning-dialog .e-dlg-header-content .e-btn.e-icon-btn {
    background: rgba(255, 255, 255, 0.2) !important;
    color: white !important;
    border-radius: 50% !important;
}

.warning-dialog .e-dlg-header-content .e-btn.e-icon-btn:hover {
    background: rgba(255, 255, 255, 0.4) !important;
    transform: rotate(90deg) !important;
}
```

**Error Dialog Close Button:**
```css
.error-dialog .e-dlg-header-content .e-btn.e-icon-btn {
    background: rgba(255, 255, 255, 0.2) !important;
    color: white !important;
    border-radius: 50% !important;
}

.error-dialog .e-dlg-header-content .e-btn.e-icon-btn:hover {
    background: rgba(255, 255, 255, 0.4) !important;
    transform: rotate(90deg) !important;
}
```

---

### Content

The Dialog content area (`e-dlg-content`) features gradient backgrounds, custom text colors, typography settings, and padding. Each Dialog type uses different color schemes to convey the message type (info, success, warning, error).

**Code Snippet:**
```css
.info-dialog .e-dlg-content {
    background: linear-gradient(to bottom, #ebf4ff, #ffffff) !important;
    color: #2d3748 !important;
    font-size: 15px !important;
    font-weight: 500 !important;
    padding: 25px 20px !important;
    line-height: 1.6 !important;
    margin: 0 !important;
}
```

**Success Dialog Content:**
```css
.success-dialog .e-dlg-content {
    background: linear-gradient(to bottom, #e6fffa, #ffffff) !important;
    color: #065f46 !important;
    font-size: 15px !important;
    padding: 25px 20px !important;
    margin: 0 !important;
}
```

**Warning Dialog Content:**
```css
.warning-dialog .e-dlg-content {
    background: linear-gradient(to bottom, #fffaf0, #ffffff) !important;
    color: #7c2d12 !important;
    font-size: 15px !important;
    padding: 25px 20px !important;
    margin: 0 !important;
}
```

**Error Dialog Content:**
```css
.error-dialog .e-dlg-content {
    background: linear-gradient(to bottom, #fef2f2, #ffffff) !important;
    color: #991b1b !important;
    font-size: 15px !important;
    padding: 25px 20px !important;
    margin: 0 !important;
}
```

---

### Footer

The footer section (`e-footer-content`) can be customized with background colors, borders, and layout properties. It supports flexbox layout for button arrangement with custom spacing and alignment.

**Code Snippet:**
```css
.info-dialog .e-footer-content {
    background-color: #f7fafc !important;
    border-top: 2px solid #e2e8f0 !important;
    padding: 15px 20px !important;
    display: flex !important;
    justify-content: flex-end !important;
    gap: 10px !important;
}
```

**Success Dialog Footer:**
```css
.success-dialog .e-footer-content {
    background-color: #f0fff4 !important;
    border-top: 2px solid #c6f6d5 !important;
    padding: 15px 20px !important;
}
```

**Warning Dialog Footer:**
```css
.warning-dialog .e-footer-content {
    background-color: #fffaf0 !important;
    border-top: 2px solid #fbd38d !important;
    padding: 15px 20px !important;
}
```

**Error Dialog Footer:**
```css
.error-dialog .e-footer-content {
    background-color: #fef2f2 !important;
    border-top: 2px solid #feb2b2 !important;
    padding: 15px 20px !important;
}
```

---

### Footer Buttons

Footer buttons support gradient backgrounds, box shadows, hover animations, and active state effects. The buttons include smooth transitions and transform effects for enhanced user interaction.

**Code Snippet:**
```css
.info-dialog .e-footer-content .e-btn {
    background: linear-gradient(135deg, #667eea 0%, #764ba2 100%) !important;
    color: white !important;
    border: none !important;
    border-radius: 6px !important;
    padding: 10px 24px !important;
    font-weight: 600 !important;
    font-size: 14px !important;
    text-transform: uppercase !important;
    letter-spacing: 0.5px !important;
    box-shadow: 0 4px 6px rgba(102, 126, 234, 0.3) !important;
    transition: all 0.3s ease !important;
}

.info-dialog .e-footer-content .e-btn:hover {
    transform: translateY(-2px) !important;
    box-shadow: 0 6px 12px rgba(102, 126, 234, 0.4) !important;
    background: linear-gradient(135deg, #764ba2 0%, #667eea 100%) !important;
}

.info-dialog .e-footer-content .e-btn:active {
    transform: translateY(0) !important;
    box-shadow: 0 2px 4px rgba(102, 126, 234, 0.2) !important;
}
```

**Success Dialog Footer Buttons:**
```css
.success-dialog .e-footer-content .e-btn {
    background: linear-gradient(135deg, #11998e 0%, #38ef7d 100%) !important;
    color: white !important;
    border: none !important;
    border-radius: 6px !important;
    padding: 10px 24px !important;
    font-weight: 600 !important;
    box-shadow: 0 4px 6px rgba(17, 153, 142, 0.3) !important;
}

.success-dialog .e-footer-content .e-btn:hover {
    transform: translateY(-2px) !important;
    box-shadow: 0 6px 12px rgba(17, 153, 142, 0.4) !important;
}
```

**Warning Dialog Footer Buttons:**
```css
.warning-dialog .e-footer-content .e-btn {
    background: linear-gradient(135deg, #f093fb 0%, #f5576c 100%) !important;
    color: white !important;
    border: none !important;
    border-radius: 6px !important;
    padding: 10px 24px !important;
    font-weight: 600 !important;
    box-shadow: 0 4px 6px rgba(245, 87, 108, 0.3) !important;
}

.warning-dialog .e-footer-content .e-btn:hover {
    transform: translateY(-2px) !important;
    box-shadow: 0 6px 12px rgba(245, 87, 108, 0.4) !important;
}
```

**Error Dialog Footer Buttons:**
```css
.error-dialog .e-footer-content .e-btn {
    background: linear-gradient(135deg, #eb3349 0%, #f45c43 100%) !important;
    color: white !important;
    border: none !important;
    border-radius: 6px !important;
    padding: 10px 24px !important;
    font-weight: 600 !important;
    box-shadow: 0 4px 6px rgba(235, 51, 73, 0.3) !important;
}

.error-dialog .e-footer-content .e-btn:hover {
    transform: translateY(-2px) !important;
    box-shadow: 0 6px 12px rgba(235, 51, 73, 0.4) !important;
}
```

---

### Overlay

The overlay (`e-dlg-overlay`) can be customized with background colors, opacity levels, and backdrop blur effects. It creates the modal effect that brings focus to the Dialog content.

**Code Snippet:**
```css
.info-dialog + .e-dlg-overlay {
    background-color: rgba(102, 126, 234, 0.5) !important;
    backdrop-filter: blur(4px) !important;
}
```

**Success Dialog Overlay:**
```css
.success-dialog + .e-dlg-overlay {
    background-color: rgba(17, 153, 142, 0.5) !important;
    backdrop-filter: blur(4px) !important;
}
```

**Warning Dialog Overlay:**
```css
.warning-dialog + .e-dlg-overlay {
    background-color: rgba(245, 87, 108, 0.5) !important;
    backdrop-filter: blur(4px) !important;
}
```

**Error Dialog Overlay:**
```css
.error-dialog + .e-dlg-overlay {
    background-color: rgba(235, 51, 73, 0.5) !important;
    backdrop-filter: blur(4px) !important;
}
```

---

## Custom PredefinedDialog - Advanced Complete Styling

### Overview

This section demonstrates an advanced, fully customized Dialog style with sophisticated design elements including gradient headers, animated overlays, custom icons, and advanced button effects.

**Description:**
The custom Dialog implementation showcases professional Dialog design patterns with:
- Custom border radius and layered shadows
- Animated gradient headers with decorative patterns
- Content sections with emoji icons
- Advanced button effects with shimmer animations
- Responsive adjustments for mobile devices

### Complete Custom Dialog Styling

**Code Snippet:**

```css
/* Base Custom Dialog Container */
.custom-dialog {
    border-radius: 16px !important;
    box-shadow: 0 20px 60px rgba(0, 0, 0, 0.3) !important;
    border: 1px solid #e2e8f0 !important;
    overflow: hidden !important;
}

/* Header Section with Gradient and Decorative Line */
.custom-dialog .e-dlg-header-content {
    background: linear-gradient(135deg, #ff6b6b 0%, #556270 100%) !important;
    border-bottom: none !important;
    padding: 24px 24px 20px 24px !important;
    position: relative !important;
}

.custom-dialog .e-dlg-header-content::after {
    content: '' !important;
    position: absolute !important;
    bottom: 0 !important;
    left: 0 !important;
    right: 0 !important;
    height: 3px !important;
    background: repeating-linear-gradient(90deg, #ff6b6b, #ff6b6b 10px, #556270 10px, #556270 20px) !important;
}

/* Header Text Styling */
.custom-dialog .e-dlg-header-content .e-dlg-header {
    color: white !important;
    font-weight: 800 !important;
    font-size: 20px !important;
    text-transform: uppercase !important;
    letter-spacing: 2px !important;
    text-shadow: 2px 2px 4px rgba(0,0,0,0.3) !important;
}

/* Advanced Close Button with Border and Animations */
.custom-dialog .e-dlg-header-content .e-btn.e-icon-btn {
    background: rgba(255, 255, 255, 0.15) !important;
    color: white !important;
    border: 2px solid rgba(255, 255, 255, 0.5) !important;
    width: 36px !important;
    height: 36px !important;
    border-radius: 50% !important;
    transition: all 0.3s ease !important;
}

.custom-dialog .e-dlg-header-content .e-btn.e-icon-btn:hover {
    background: rgba(255, 255, 255, 0.4) !important;
    border-color: white !important;
    transform: rotate(90deg) scale(1.1) !important;
}

/* Content Section with Icon and Custom Layout */
.custom-dialog .e-dlg-content {
    background: #ffffff !important;
    color: #2d3748 !important;
    font-size: 16px !important;
    line-height: 1.8 !important;
    padding: 30px 24px !important;
    position: relative !important;
}

.custom-dialog .e-dlg-content::before {
    content: '💡' !important;
    position: absolute !important;
    top: 20px !important;
    left: 15px !important;
    font-size: 24px !important;
}

.custom-dialog .e-dlg-content div {
    padding-left: 35px !important;
}

/* Advanced Footer Section */
.custom-dialog .e-footer-content {
    background: linear-gradient(to right, #f7fafc, #edf2f7) !important;
    border-top: 3px solid #e2e8f0 !important;
    padding: 20px 24px !important;
    display: flex !important;
    justify-content: center !important;
    gap: 15px !important;
}

/* Advanced Footer Buttons with Shimmer Effect */
.custom-dialog .e-footer-content .e-btn {
    background: linear-gradient(135deg, #667eea 0%, #764ba2 100%) !important;
    color: white !important;
    border: none !important;
    border-radius: 50px !important;
    padding: 12px 32px !important;
    font-weight: 700 !important;
    font-size: 14px !important;
    text-transform: uppercase !important;
    letter-spacing: 1px !important;
    box-shadow: 0 4px 15px rgba(102, 126, 234, 0.4) !important;
    transition: all 0.3s ease !important;
    position: relative !important;
    overflow: hidden !important;
}

/* Shimmer Animation Effect on Button */
.custom-dialog .e-footer-content .e-btn::before {
    content: '' !important;
    position: absolute !important;
    top: 0 !important;
    left: -100% !important;
    width: 100% !important;
    height: 100% !important;
    background: linear-gradient(90deg, transparent, rgba(255,255,255,0.3), transparent) !important;
    transition: left 0.5s ease !important;
}

.custom-dialog .e-footer-content .e-btn:hover::before {
    left: 100% !important;
}

/* Button Hover Effects */
.custom-dialog .e-footer-content .e-btn:hover {
    transform: translateY(-3px) scale(1.05) !important;
    box-shadow: 0 8px 25px rgba(102, 126, 234, 0.5) !important;
}

.custom-dialog .e-footer-content .e-btn:active {
    transform: translateY(-1px) scale(1.02) !important;
}

/* Advanced Overlay with Backdrop Blur */
.custom-dialog + .e-dlg-overlay {
    background-color: rgba(0, 0, 0, 0.6) !important;
    backdrop-filter: blur(8px) !important;
    animation: overlayFadeIn 0.3s ease-out !important;
}

```
**Playground Sample with Demo !**