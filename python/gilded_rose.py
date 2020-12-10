# -*- coding: utf-8 -*-

SULFURAS = "Sulfuras, Hand of Ragnaros"
BACKSTAGE_PASS = "Backstage passes to a TAFKAL80ETC concert"
AGED_BRIE = "Aged Brie"

class GildedRose(object):
    def is_aged_brie(self, item):
        return item.name == AGED_BRIE

    def is_backstage_pass(self, item):
        return item.name == BACKSTAGE_PASS

    def is_sulfuras(self, item):
        return item.name == SULFURAS

    def get_updated_quality_for_backstage_pass(self, item):
        quality = item.quality + 1
        if item.sell_in < 0:
            quality = 0
        elif item.sell_in < 5:
            quality += 2
        elif item.sell_in < 10:
            quality += 1
                        
        return min([50, quality])

    def get_updated_quality_for_aged_brie(self, item):
        if item.sell_in < 0 & item.quality < 49:
            item.quality += 2
        else:
            item.quality += 1
            
        return min([50, item.quality])

    def get_updated_quality_regular_item(self, item):
        if item.sell_in < 0:
            item.quality -= 2
        else:
            item.quality -= 1
        return max([0, item.quality])

    def get_updated_sell_in(self, item):
        return item.sell_in if self.is_sulfuras(item) else item.sell_in - 1

    def __init__(self, items):
        self.items = items

    def update_quality(self):
        for item in self.items:
            item.sell_in = self.get_updated_sell_in(item)

            if self.is_aged_brie(item):
                item.quality = self.get_updated_quality_for_aged_brie(item)

            elif self.is_backstage_pass(item):
                item.quality = self.get_updated_quality_for_backstage_pass(item)

            elif self.is_sulfuras(item):
                pass

            else:
                item.quality = self.get_updated_quality_regular_item(item)

class Item:
    def __init__(self, name, sell_in, quality):
        self.name = name
        self.sell_in = sell_in
        self.quality = quality

    def __repr__(self):
        return "%s, %s, %s" % (self.name, self.sell_in, self.quality)
