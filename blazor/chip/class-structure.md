---
layout: post
title: Blazor Chip CSS classes and their descriptions | Syncfusion
description: Check out and learn all about CSS classes and their descriptions in the Syncfusion Blazor Chip component.
platform: Blazor
control: Chip
documentation: ug
---

# CSS Classes in the Blazor Chip Component

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor [Chip](https://www.syncfusion.com/blazor-components/blazor-chips) component is a compact element that represents an input, attribute, or action. It supports avatars, icons, delete functionality, multi-selection mode, drag-and-drop, and RTL layout. This document lists the component's CSS classes and explains their purpose.

## Root and container classes

| CSS Class | Description |
|-----------|-------------|
| `.e-chip-list` | Applied to the root container element of the Chip component. Defines flex display and controls padding for the chip collection. Can be applied to a single chip or a collection of multiple chips. |
| `.e-chip-list:not(.e-chip)` | Applied to chip list containers that hold multiple chips (not a single chip element). Enables flex-wrap to allow chips to wrap to multiple lines when the container width is exceeded. |
| `.e-clone-chip` | Applied to cloned chip elements during drag-and-drop operations. Sets a high z-index to ensure the cloned chip appears above other elements while dragging. |

## Chip item classes

| CSS Class | Description |
|-----------|-------------|
| `.e-chip` | Applied to individual chip elements. Defines core chip styling including border, border-radius, box-shadow, cursor, height, padding, font properties, and transitions. Sets the chip as an inline-flex container with centered alignment and user interaction behaviors. |
| `.e-chip.e-outline` | Applied to chips with outline styling variant. Provides alternative visual styling with adjusted avatar sizing and border rendering for outline-style chips. |

## Content classes

| CSS Class | Description |
|-----------|-------------|
| `.e-chip-text` | Applied to the text content element within a chip. Controls text overflow behavior with ellipsis, enforces single-line display with nowrap, and manages text height for proper vertical alignment. |
| `.e-chip-template` | Applied to custom template content within a chip. Sets inline-flex display to allow flexible content layout when using custom templates instead of standard text. |

## Avatar classes

| CSS Class | Description |
|-----------|-------------|
| `.e-chip-avatar` | Applied to the avatar element positioned at the leading edge of a chip. Controls avatar dimensions and border-radius for circular appearance. Manages font size for initials or content, spacing from adjacent elements, and centers content using flex alignment. Includes background-size cover and overflow hidden for proper image rendering. |
| `.e-chip-avatar-wrap` | Applied to chip elements that contain an avatar. Ensures proper border-radius styling to accommodate the avatar's circular shape at the chip's leading edge. In multi-selection mode, controls the display behavior of the selection indicator when the chip state changes. |
| `.e-chip.e-outline .e-chip-avatar` | Applied to avatars within outline-variant chips. Adjusts avatar sizing and border-radius to maintain visual consistency with the outline chip style, providing specific dimensions for the outline variant. |

## Icon classes

| CSS Class | Description |
|-----------|-------------|
| `.e-chip-icon` | Applied to the leading icon element within a chip. Controls icon dimensions, border-radius, font size, margin for spacing, and centering. Uses flex display with background-size cover for proper icon rendering. Positioned before the chip text content. |
| `.e-chip-icon-wrap` | Applied to chip elements that contain a leading icon. In multi-selection mode, controls the visibility transition between the icon and selection indicator when the chip state changes. |
| `.image-url` | Applied to image-based leading icons using URL references. Controls image dimensions, border-radius, font size, margin, and centering with flex display and background-size cover for proper image scaling. Functions similarly to `.e-chip-icon` but specifically for image assets. |

## Delete icon classes

| CSS Class | Description |
|-----------|-------------|
| `.e-chip-delete` | Applied to the delete icon element at the trailing edge of a chip. Controls delete icon dimensions, border-radius, font size, margin, and alignment. Provides the visual button for removing chips with flex display and centered content. |
| `.e-chip-delete.e-dlt-btn::before` | Applied to the before pseudo-element of the delete button with class `.e-dlt-btn`. Sets the icon font family to 'e-icons' for rendering the Syncfusion delete icon glyph. |
| `.trailing-icon-url` | Applied to custom trailing icons using URL references. Controls trailing icon dimensions, border-radius, font size, margin, and alignment. Sets the icon font family to 'e-icons' for proper icon rendering. Functions as a customizable alternative to the standard delete icon. |

## Drag and drop classes

| CSS Class | Description |
|-----------|-------------|
| `.e-chip-drag` | Applied to the drag handle element within a chip. Serves as the base class for drag functionality, enabling users to reorder chips through drag-and-drop interactions. |
| `.e-chip-drag.e-drag-and-drop` | Applied to drag handle elements when standard chip drag-and-drop functionality is enabled. Controls margin spacing for the drag icon to properly position it within the chip layout. |
| `.e-chip-drag.e-error-treeview` | Applied to drag handle elements when used in specific component contexts such as tree-view controls. Controls margin spacing to maintain consistent visual alignment across different component integrations. |

## Multi-selection classes

| CSS Class | Description |
|-----------|-------------|
| `.e-multi-selection` | Applied to the chip list container when multi-selection mode is enabled. Enables selection indicators for chips and manages transition animations for smooth state changes. Allows multiple chips to be selected simultaneously. |

## State classes

| CSS Class | Description |
|-----------|-------------|
| `.e-chip.e-active` | Applied to chips in their selected/active state. In multi-selection mode, triggers visibility changes for icons and avatars, hiding them to display the selection indicator instead. Represents the currently selected chip with appropriate visual styling. |

### Multi-selection state classes

The following classes are applied specifically in multi-selection mode to manage selection indicators:

| CSS Class | Description |
|-----------|-------------|
| `.e-multi-selection .e-chip.e-active .e-chip-icon` | Applied to the leading icon of an active chip in multi-selection mode. Hides the icon to allow the selection indicator to be shown in its place. |
| `.e-multi-selection .e-chip.e-active .e-chip-avatar` | Applied to the avatar of an active chip in multi-selection mode. Hides the avatar to allow the selection indicator to be shown in its place. |

## RTL (right-to-left) classes

| CSS Class | Description |
|-----------|-------------|
| `.e-rtl` | Applied to the chip list container when RTL (right-to-left) mode is enabled. Reverses the layout direction for all child chips, adjusting margins and positioning to mirror the default left-to-right layout. Ensures proper display for right-to-left languages. |
| `.e-rtl .e-chip-avatar` | Applied to avatars in RTL mode chips. Adjusts margin values to position the avatar on the right edge instead of the left, mirroring the default LTR layout. |
| `.e-rtl .e-chip-icon` | Applied to leading icons in RTL mode chips. Adjusts margin values to position the icon on the right edge instead of the left for proper RTL alignment. |
| `.e-rtl .e-chip-delete` | Applied to delete icons in RTL mode chips. Adjusts margin values to position the delete icon on the left edge instead of the right in RTL layout. |
| `.e-rtl .e-chip-avatar-wrap` | Applied to avatar wrapper elements in RTL mode chips. Adjusts border-radius values to maintain proper circular shape positioning when the avatar is on the right side in right-to-left layout. |
| `.e-rtl .trailing-icon-url` | Applied to custom trailing icons in RTL mode chips. Adjusts margin to position the trailing icon correctly on the left side in right-to-left layout. |
| `.e-rtl .e-chip-drag.e-drag-and-drop` | Applied to drag handles in RTL mode chips during drag-and-drop operations. Adjusts margin to position the drag icon correctly in right-to-left layout. |
| `.e-rtl .e-chip-drag.e-error-treeview` | Applied to drag handles in RTL mode chips when used in alternative component contexts. Adjusts margin for proper RTL positioning of the drag icon to maintain consistent alignment. |

### RTL multi-selection classes

The following classes are applied specifically in RTL mode with multi-selection enabled:

| CSS Class | Description |
|-----------|-------------|
| `.e-rtl.e-multi-selection .e-chip::before` | Applied to the selection indicator pseudo-element in RTL mode. Adjusts margin positioning to properly display the selection indicator on the right side in right-to-left layout. |
| `.e-rtl.e-multi-selection .e-chip.e-chip-avatar-wrap::before` | Applied to the selection indicator pseudo-element for chips with avatars in RTL mode. Adjusts margin positioning specifically for avatar-containing chips to maintain proper alignment in right-to-left layout. |
