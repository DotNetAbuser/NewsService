﻿namespace Domain.Entities;

public class LikeEntity
    : BaseEntity<int>
{
    public Guid UserId { get; set; }
    public Guid NewsId { get; set; }

    public UserEntity User { get; set; } = null!;
    public NewsEntity News { get; set; } = null!;
}