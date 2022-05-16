using UnityEngine;

namespace Assets.Scripts
{
    public abstract class ReactableEntity : Entity
    {
        public D AddDetector<D>(ReactionDataBase reactionDataBase) where D : Detector 
        {
            if (gameObject.TryGetComponent<D>(out D detector))
            {
                Debug.Log("Ошибка, такой компонент уже есть");
                return detector;
            }

            Detector detectors = gameObject.AddComponent<D>() as Detector;
            detectors.SetParametrs(reactionDataBase);
            
            return detectors as D;
        }
    }
}
