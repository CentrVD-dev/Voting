SELECT
    CASE 
        WHEN res2.name IS NOT NULL THEN CONCAT(res1.name, ' за ', res2.name)
        ELSE res1.name
    END AS voter,
    v.name AS vote,
    COALESCE(vr.comment, '') AS comment,
    vr.pointid AS decisionid,
    vr.text AS decision,
    (
        SELECT STUFF(
            (SELECT ', ' + v2.name + ' - ' + CAST(COUNT(*) AS VARCHAR(10))
             FROM centrvd_votingm_votingtaskvoti AS vr2
             JOIN centrvd_votingm_votekind AS v2 ON v2.id = vr2.vote
             WHERE vr2.pointid = vr.pointid AND vr2.task = @taskid
             GROUP BY v2.name, v2.id
             ORDER BY v2.id
             FOR XML PATH(''), TYPE).value('.', 'NVARCHAR(MAX)'), 1, 2, '')
    ) AS summary
FROM centrvd_votingm_votingtaskvoti AS vr
JOIN sungero_core_recipient AS res1 ON res1.id = vr.voter
LEFT JOIN sungero_core_recipient AS res2 ON res2.id = vr.substituted
JOIN centrvd_votingm_votekind AS v ON v.id = vr.vote
WHERE vr.task = @taskid
ORDER BY vr.pointid, voter