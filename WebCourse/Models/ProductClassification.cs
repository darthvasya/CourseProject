namespace WebCourse.Models {
    public enum DevelopmentStage {
        Прединвестиционная = 1,
        Инвестиционная = 2
    }

    public enum Prevalence {
        Единичная = 1,
        Диффузная = 2,
    }

    public enum ProductionCyclePlace {
        Сырьевая = 1,
        Обеспечивающая = 2,
        Продуктовая = 3,
    }

    public enum Continuity {
        Замещаяющая = 1,
        Отменяющая = 2,
        Возвратная = 3,
        Открывающая = 4,
        Ретровведение = 5,
    }

    public enum MarketShare {
        Локальная = 1,
        Системная = 2,
        Стратегическая = 3,
    }

    public enum MarketNoveltyDegree {
        Новая_для_отрасли_в_мире = 1,
        Новая_для_отрасли_в_стране = 2,
        Новая_для_предприятия = 3,
    }

    public enum NoveltyDegree {
        Радикальная = 1,
        Комбинаторная = 2,
        Совершенствующая = 3,
    }
}
