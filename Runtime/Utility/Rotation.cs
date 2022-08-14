using UnityEngine;

namespace AimIK.Utility
{
    using Definition;

    public static class Rotation
    {
        /// <summary>
        /// Clamp the angle between min and max
        /// </summary>
        /// <param name="angle">The input angle</param>
        /// <param name="min">The min angle</param>
        /// <param name="max">The max angle</param>
        /// <returns>The clamped angle</returns>
        public static float ClampAngle(float angle, float min, float max)
        {
            angle = NormalizeAngle(angle);

            if (angle > 180)
                angle -= 360;
            else if (angle < -180)
                angle += 360;
            min = NormalizeAngle(min);

            if (min > 180)
                min -= 360;
            else if (min < -180)
                min += 360;
            max = NormalizeAngle(max);

            if (max > 180)
                max -= 360;
            else if (max < -180)
                max += 360;

            return Mathf.Clamp(angle, min, max);
        }

        /// <summary>
        /// If the angle over 360 or under 360 degree, then normalize them
        /// </summary>
        /// <param name="angle">The input angle</param>
        /// <returns>The normalized angle</returns>
        private static float NormalizeAngle(float angle)
        {
            while (angle > 360)
                angle -= 360;
            while (angle < 0)
                angle += 360;

            return angle;
        }

        /// <summary>
        /// Rotates the 3D transforms so the forward vector points at worldPosition
        /// </summary>
        /// <param name="transform">The transform that should to look at</param>
        /// <param name="worldPosition">Point to look at</param>
        /// <param name="rotationOffset">Rotation offset</param>
        public static void LookAt3D(this Transform transform
            , Vector3 worldPosition, Vector3 rotationOffset)
        {
            Vector3 diff = worldPosition - transform.position;
            Quaternion rotation = Quaternion.LookRotation(diff);
            transform.rotation = rotation * Quaternion.Euler(rotationOffset);
        }

        /// <summary>
        /// Rotates the 2D transforms so the right vector points at worldPosition
        /// </summary>
        /// <param name="transform">The transform that should to look at</param>
        /// <param name="worldPosition">Point to look at</param>
        /// <param name="rotationOffset">Rotation offset</param>
        public static void LookAt2D(this Transform transform
            , Vector2 worldPosition, float rotationOffset)
        {
            Vector2 diff = worldPosition - new Vector2(transform.position.x, transform.position.y);
            diff.Normalize();

            float rotateZ = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, rotateZ + rotationOffset);
        }

        /// <summary>
        /// Check the 3D clamp
        /// </summary>
        /// <param name="bone">The input bone transform</param>
        /// <param name="limitRotation">The input limit rotation</param>
        /// <param name="rotation">The input rotation</param>
        public static void CheckClamp3D(this Transform bone
            , LimitRotation limitRotation, Vector3 rotation)
        {
            if (limitRotation.XAxis.IsLimitRotation)
                rotation.x = ClampAngle(bone.localEulerAngles.x
                    , limitRotation.XAxis.Min, limitRotation.XAxis.Max);
            else
                rotation.x = bone.localEulerAngles.x;

            if (limitRotation.YAxis.IsLimitRotation)
                rotation.y = ClampAngle(bone.localEulerAngles.y
                    , limitRotation.YAxis.Min, limitRotation.YAxis.Max);
            else
                rotation.y = bone.localEulerAngles.y;

            if (limitRotation.ZAxis.IsLimitRotation)
                rotation.z = ClampAngle(bone.localEulerAngles.z
                    , limitRotation.ZAxis.Min, limitRotation.ZAxis.Max);
            else
                rotation.z = bone.localEulerAngles.z;

            Vector3 boneRotation = new Vector3(rotation.x, rotation.y, rotation.z);
            bone.localEulerAngles = boneRotation;
        }

        /// <summary>
        /// Check the 2D clamp
        /// </summary>
        /// <param name="bone">The input bone transform</param>
        /// <param name="limitRotation">The input axis limit rotation</param>
        /// <param name="rotation">The input 2D rotation</param>
        public static void CheckClamp2D(this Transform bone
            , LimitRotationAxis limitRotation, float rotation)
        {
            if (limitRotation.IsLimitRotation)
                rotation = ClampAngle(bone.localEulerAngles.z
                    , limitRotation.Min, limitRotation.Max);
            else
                rotation = bone.localEulerAngles.z;

            Vector3 boneRotation = new Vector3(bone.localEulerAngles.x, bone.localEulerAngles.y, rotation);
            bone.localEulerAngles = boneRotation;
        }
    }
}