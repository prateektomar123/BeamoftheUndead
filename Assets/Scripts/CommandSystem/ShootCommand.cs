using UnityEngine;

public class ShootCommand : ICommand
{
    private TankView view;
    private BulletPoolManager bulletPoolManager;
    private Transform firePoint;
    private int ammoCost;

    public ShootCommand(TankView view, BulletPoolManager bulletPoolManager, Transform firePoint, int ammoCost)
    {
        this.view = view;
        this.bulletPoolManager = bulletPoolManager;
        this.firePoint = firePoint;
        this.ammoCost = ammoCost;
    }

    public void Execute()
    {
        view.PlayShootAnimation();
        BulletController bullet = bulletPoolManager.GetBullet(firePoint.position, firePoint.rotation);
        bullet.Initialize(firePoint.forward, bulletPoolManager);
        ServiceLocator.Get<AudioService>().PlaySound("Shoot");
    }
}